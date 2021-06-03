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
using Microsoft.AspNetCore.Authorization;

namespace SecondHandWeb.Controllers
{
    public class ADMController : Controller
    {
        private readonly BusinesFacade _businesFacade;
        public readonly UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _environment;

        public ADMController(BusinesFacade businesFacade, SecondHandContext context,
                                   UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _businesFacade = businesFacade;
            _environment = environment;
            _userManager = userManager;
        }

        // GET: ADM
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: ADM/NroTotalVendaPeriodo/
        [Authorize]
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
    }
}
