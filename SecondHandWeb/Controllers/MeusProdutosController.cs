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
        private readonly SecondHandContext _ct;
        public readonly UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _environment;

        public MeusProdutosController(BusinesFacade businesFacade, SecondHandContext ff,
                                   UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {           
            _businesFacade = businesFacade;
            _environment = environment;
            _userManager = userManager;
            _ct = ff;
        }

        [Authorize]
        // GET: MeusProdutos
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(HttpContext.User);
            String usu = _businesFacade.getUserID(usuario.UserName);
            return View(_businesFacade.ItensPorStatusUsu(usu));
        }

        [Authorize]
        // GET: MeusProdutos/Details/5
        public IActionResult Details(long id)
        {
            if (id == 0)
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
        // GET: MeusProdutos/Edit/5
        public async Task<IActionResult> Edit(long? id)
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
            ViewData["CategoriaName"] = new SelectList(_businesFacade.categoriasIEnumerable(), "CategoriaId", "Name");
            return View(produto);
        }

        [Authorize]
        // POST: MeusProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ProdutoId,Name,Descricao,Estado,Valor,DataEntrada,DataVenda,UsuarioID,Categoria")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _businesFacade.editProduto(produto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaName"] = new SelectList(_businesFacade.categoriasIEnumerable(), "CategoriaId", "Name");
            return View(produto);
        }

        [Authorize]
        // GET: MeusProdutos/Delete/5
        public async Task<IActionResult> Delete(long? id)
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
        // POST: MeusProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            _businesFacade.deletaProduto(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(long id)
        {
            return _businesFacade.existe(id);
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
