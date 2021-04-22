using BLL;
using Entities.Models;
using PL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            SecondHandContext context = new SecondHandContext();

            #region testando conteudo de cada "tabela"
            List<Produto> prod = context.Produtos.ToList();
            List<Categoria> cate = context.Categorias.ToList();

            foreach (Produto p in prod)
            {
                Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}  {6}",
                                    p.ProdutoId, p.Name, p.Descricao, p.Estado, p.Valor, p.Vendedor, p.CategoriaID);
            }
            Console.WriteLine("\n\n");

            foreach (Categoria c in cate)
            {
                Console.WriteLine("{0}  {1}",
                                    c.CategoriaId, c.Name);
            }
            Console.WriteLine("\n\n");
            #endregion
        }
    }
}
