using Entities.Interfaces;
using Entities.Models;
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
        public ApplicationUser PerfilVendedor(String nomeVendedor)
        {
            /*var perfilVendedor = _context.ApplicationUser
                            .Where(a => a.UserName.Equals(nomeVendedor))
                            .Select*/
            var perfilVendedor = _context.ApplicationUser
                            .Where(a => a.Nome.Equals(nomeVendedor))
                            .Select(a => a)
                            .FirstOrDefault();

            return perfilVendedor;
        }
    }
}
