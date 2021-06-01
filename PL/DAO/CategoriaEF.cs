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
    public class CategoriaEF : ICategoriaDAO
    {
        private readonly SecondHandContext _context;

        //construtor produtos entity framework        

        public CategoriaEF (SecondHandContext context)
        {
            _context = context;
        }

        //retorna o nome de todas as categorias de produtos cadastrados
        public IQueryable<String> categoriasNomes()
        {
            var categoriaQuery = (from m in _context.Categorias
                              orderby m.Name
                              select m.Name);

            return categoriaQuery;
        }

        //retorna um IEnumerable de categorias
        public IEnumerable<Categoria> categoriasIEnumerable()
        {
            var ienume = from m in _context.Categorias
                         select m;

            return ienume;
        }
    }
}
