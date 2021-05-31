using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using PL;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SecondHandWeb.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        public readonly UserManager<Usuario> _userManager;
        BusinesFacade _bll = new BusinesFacade();

        public ProdutoController(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        // GET: Produto
        //public async Task<IActionResult> Index()
        public IActionResult Index()
        {

            List<Produto> produtos = _bll.listaDeProdutos();
            return View(produtos);
        }

        [AllowAnonymous]
        // GET: Produto/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produto = _bll.ItemPorId((long)id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,Name,Descricao,Estado,Valor,DataEntrada,DataVenda,UsuarioId,Categoria")] Produto produto)
        {
            var usuario = await _userManager.GetUserAsync(HttpContext.User);
            produto.Vendedor = usuario.UserName;
            if (ModelState.IsValid)
            {
                _bll.NovoProduto(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produto/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _bll.ItemPorId((long)id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("ProdutoId,Name,Descricao,Valor,DataEntrada,UsuarioId,Categoria")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.AtualizaProduto(produto);
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
            return View(produto);
        }

        // GET: Produto/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _bll.ItemPorId((long)id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            _bll.DeletaProduto(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(long id)
        {
            return _bll.ProdutoExiste(id);
        }

        //Pegando o usuário logado.
        public async Task<IActionResult> dadosUsuario()
        {
            var usuario = await _userManager.GetUserAsync(User);

            ViewBag.Id = usuario.Id;
            ViewBag.UserName = usuario.UserName;

            return View();
        }
    }
}