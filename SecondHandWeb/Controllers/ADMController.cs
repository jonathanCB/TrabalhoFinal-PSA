using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using PL.Context;
using Microsoft.AspNetCore.Identity;
using BLL;
using Microsoft.AspNetCore.Hosting;
using Entities.ViewModels;
using SecondHandWeb.Models;

namespace SecondHandWeb.Controllers
{
    public class ADMController : Controller
    {
        private readonly BusinesFacade _businesFacade;
        private readonly SecondHandContext _context;
        public readonly UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _environment;

        public ADMController(BusinesFacade businesFacade, SecondHandContext context,
                                   UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _context = context;
            _businesFacade = businesFacade;
            _environment = environment;
            _userManager = userManager;
        }

        // GET: ADM
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: ADM/NroTotalVendaPeriodo/
        public async Task<IActionResult> TotVendPeriodo(DateTime dtIni, DateTime dtFim)
        {
            if (dtIni > dtFim)
            {
                return NotFound();
            }

            int t = -1;
            decimal v = -1;
            foreach (TotalVendaPorPeriodo i in _businesFacade.TotalVendaPeriodo(dtIni, dtFim))
            {
                t = i.numVendasPeriodo; 
                v =  i.valorVendasPeriodo;
            }

            var TotalVendaPorPeriodo = new TotalVendaPorPeriodoViewModel
            {
                numVendasPeriodo = t,
                valorVendasPeriodo = v                
            };

            return View(TotalVendaPorPeriodo);
        }

        // GET: ADM/Create
        public IActionResult Create()
        {
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "CategoriaId", "Name");
            return View();
        }

        // POST: ADM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,Name,Descricao,Estado,Valor,DataEntrada,DataVenda,UsuarioIDVendedor,NomeVendedor,UsuarioIDComprador,NomeComprador,CategoriaID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                //var usuario = await _userManager.GetUserAsync(HttpContext.User);
                //produto.UsuarioIDVendedor = _businesFacade.getUserID(usuario.UserName);

                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "CategoriaId", "Name", produto.CategoriaID);
            return View(produto);
        }

        // GET: ADM/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "CategoriaId", "Name", produto.CategoriaID);
            return View(produto);
        }

        // POST: ADM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ProdutoId,Name,Descricao,Estado,Valor,DataEntrada,DataVenda,UsuarioIDVendedor,NomeVendedor,UsuarioIDComprador,NomeComprador,CategoriaID")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
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
            ViewData["CategoriaID"] = new SelectList(_context.Categorias, "CategoriaId", "Name", produto.CategoriaID);
            return View(produto);
        }

        // GET: ADM/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: ADM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(long id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
