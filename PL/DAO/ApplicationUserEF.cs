using Entities.Interfaces;
using Entities.Models;
using Entities.ViewModels;
using PL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.DAO
{
    public class ApplicationUserEF : IApplicationUserDAO
    {
        private readonly SecondHandContext _context;

        //construtor produtos entity framework        

        public ApplicationUserEF(SecondHandContext context)
        {
            _context = context;
        }    

        public string getUserID(string userName)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName.Equals(userName));
            return user.Id;
        }
        public ApplicationUser PerfilVendedor(long id)
        {
            var nomeVendedor = _context.Produtos
                .Where(p => p.ProdutoId == id)
                .Select(p => p.NomeVendedor)
                .FirstOrDefault();
            
            var vendedor = _context.ApplicationUser
                .Where(u => u.UserName.Equals(nomeVendedor))
                .FirstOrDefault();

            return vendedor;
        }
    }
}
