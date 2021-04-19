using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Entities.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> ExibirTodos();
        void Gravar(T obj);
        DataTable Consultar(string nome);
        
    }
}
