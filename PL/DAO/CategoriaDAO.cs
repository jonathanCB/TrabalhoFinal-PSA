using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PL.DAO
{
    public class CategoriaDAO<T> : ICategoriaDAO<T>
    {
        public DataTable Consultar(string nome)
        {
            throw new NotImplementedException();
        }

        public List<T> ExibirTodos()
        {
            throw new NotImplementedException();
        }

        public void Gravar(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
