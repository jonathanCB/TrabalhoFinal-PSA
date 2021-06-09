 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using PL.Context;
using BLL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace SecondHandWeb.Controllers
{
    public class MeusProdutosController : Controller
    {
        private readonly BusinesFacade _businesFacade;
        public readonly UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _environment;

        public MeusProdutosController(BusinesFacade businesFacade,
                                   UserManager<ApplicationUser> userManager, 
                                   IWebHostEnvironment environment)
        {           
            _businesFacade = businesFacade;
            _environment = environment;
            _userManager = userManager;
        }

        [Authorize]
        // GET: MeusProdutos
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(HttpContext.User);
            String usu = _businesFacade.getUserID(usuario.UserName);
            if (usuario != null)
            {
                ViewData["usuario"] = usuario;
            }
            return View(_businesFacade.ItensPorStatusUsu(usu));
        }

        [Authorize]
        // GET: MeusProdutos/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _businesFacade.ItemPorId((long)id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [Authorize]
        // GET: MeusProdutos/Create
        public async Task<IActionResult> Create()
        {

            ViewData["CategoriaName"] = new SelectList(_businesFacade.categoriasIEnumerable(), "CategoriaId", "Name");

            var usuario = await _userManager.GetUserAsync(HttpContext.User);

            Produto novo = new Produto()
            {
                UsuarioIDVendedor = usuario.Id,
                NomeVendedor = usuario.UserName,
                DataEntrada = DateTime.Now
            };

            return View(novo);
        }

        [Authorize]
        // POST: MeusProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Descricao,Estado,Valor,DataEntrada,UsuarioIDVendedor,NomeVendedor,CategoriaID")] Produto produto)
        { 

            if (ModelState.IsValid)
            {
                _businesFacade.CadNovoProduto(produto);
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaName"] = new SelectList(_businesFacade.categoriasIEnumerable(), "CategoriaId", "Name", produto.CategoriaID);
            return View(produto);

        }

        [Authorize]
        //GET: MeusProdutos/ResponderCompra
        public async Task<IActionResult> ResponderCompra(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _businesFacade.ItemPorId((long)id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);            
        }

        [Authorize]
        //MeusProdutos/AceitarCompra
        public async Task<IActionResult> AceitarCompra(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _businesFacade.CompradoAceitouVendaProduto((long)id);
            if (produto == false)
            {
                return NotFound();
            }

            return View(_businesFacade.ItemPorId((long)id));
        }

        [Authorize]
        //MeusProdutos/NegarCompra
        public async Task<IActionResult> NegarCompra(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = await _userManager.GetUserAsync(HttpContext.User);

            var produto = _businesFacade.CompradoNegouVendaProduto((long)id);
            var rep = _businesFacade.DiminuiRep(usuario.UserName);

            if (produto == true && rep == true )
            {
                return View(_businesFacade.ItemPorId((long)id));
            }

            return NotFound();
        }

        //dados do usuario
        public async Task<IActionResult> DadosUsuario()
        {
            var usuario = await _userManager.GetUserAsync(HttpContext.User);

            ViewBag.Id = usuario.Id;
            ViewBag.UserName = usuario.UserName;

            return View();

        }

        public ActionResult GetImage(int id)
        {
            Imagem im = _businesFacade.GetImagem(id);
            if (im != null)
            {
                return File(im.ImageFile, im.ImageMimeType);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult LoadFiles(long ProdutoId, List<IFormFile> files)
        {
            _businesFacade.CadImagem(ProdutoId, files);

            return View("Details", _businesFacade.ItemPorId(ProdutoId));
        }
    }
}
