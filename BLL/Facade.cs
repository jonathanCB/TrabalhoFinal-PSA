using Entities.Models;
using PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class AdmFacade
    {

        // atencao...
        //      - apenas um exemplo
        //      - implementar DAO para acesso ao DB
        //      - "tentar" usar DI
        public void Add(Grupo g)
        {
            using (var _context = new SecondHandContext() )
           {
                _context.Add(g);
                _context.SaveChanges();
            }

        }

        public List<Grupo> GetGrupos()
        {
            SecondHandContext _context = new SecondHandContext();
            var grupos = _context.Grupo.ToList();
           
            return grupos;
        }
    }
}
