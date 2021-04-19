using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PL.DAO
{
    public class ProdutoDAO<T> : IProdutoDAO<T>
    {
        List<T> IRepositorio<T>.ExibirTodos()
        {
            throw new NotImplementedException();
        }

        public void Gravar(T obj)
        {
            throw new NotImplementedException();
        }

        DataTable IRepositorio<T>.Consultar(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
