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
using System.IO;
using SecondHandWeb.Models;

namespace SecondHandWeb.Controllers
{
    public class ProdutosDisponiveisController : Controller
    {
        private readonly BusinesFacade _businesFacade;
        public readonly UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _environment;

        public ProdutosDisponiveisController(BusinesFacade businesFacade,
                                   UserManager<ApplicationUser> userManager, 
                                   IWebHostEnvironment environment)
        {
            _businesFacade = businesFacade;
            _environment = environment;
            _userManager = userManager;
        }

        // GET: ProdutosDisponiveis
        [AllowAnonymous]
        public async Task<IActionResult> Index(string ProdutosCategoria, string searchString)
        {
            var categoriaQuery = _businesFacade.categoriasNomes();
            var produtos = _businesFacade.IQuerDeProdutosDisponiveis();

            if (!string.IsNullOrEmpty(searchString))
            {
                produtos = _businesFacade.ItensPalChavDisponiveis(searchString);
            }

            if (!string.IsNullOrEmpty(ProdutosCategoria))
            {
                produtos = _businesFacade.ItensPorCategoriaDisponiveis(ProdutosCategoria);
            }

            var produtoCategoriaVM = new ProdutoCategoriaViewModel
            {
                Categorias = new SelectList(categoriaQuery.Distinct().ToList()),
                Produtos = produtos.ToList()
            };

            return View(produtoCategoriaVM);
        }

        // GET: ProdutosDisponiveis/Details/
        [AllowAnonymous]
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

        // GET: ProdutosDisponiveis/Compra/
        [Authorize]
        public async Task<IActionResult> CompraAsync(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            //Pegando o usuário logado:
            var usuario = await _userManager.GetUserAsync(HttpContext.User);

            //Pegando o produto que está sendo comprado:
            var produto = _businesFacade.ItemPorId((long)id);

            //Colocando o nome e o id do comprador no produto:
            produto.NomeComprador = usuario.UserName;
            produto.UsuarioIDComprador = usuario.Id;

            //Alterando estado do produto para 'vendido':
            produto.Estado = StatusProduto.Status.Vendido;

            //Salvando produto:
            _businesFacade.editProduto(produto);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
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

    }
}
