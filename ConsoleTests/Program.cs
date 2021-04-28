using BLL;
using Entities.Models;
using Entities.ViewModels;
using PL;
using PL.DAO;
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

            /*ProdutoEF cons = new ProdutoEF();
            Console.WriteLine("Consulta por categoria: " + cons.ItenCategorias("Celular").ToString());*/
            

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

            #region testando consultas da entrega 1            

            Console.WriteLine("1 - Itens a venda de uma determinada categoria = Celular");
            String cat = "Celular";

            var consulta1 = context.Produtos
                            .Where(p => p.Estado == StatusProduto.Status.Disponivel)
                            .Where(p => p.Categoria.ToUpper() == cat.ToUpper())
                            .Select(p => new
                            {
                                p.Name,
                                p.Descricao,
                                p.Valor,
                                p.Vendedor,
                                p.Categoria
                            });

            foreach (var p in consulta1)
            {
                Console.WriteLine("Name:{0}  Descricao:{1}  Valor:{2}  Vendedor:{3}  Categoria:{4}",
                                    p.Name, p.Descricao, p.Valor, p.Vendedor, p.Categoria);
            }

            Console.WriteLine("\n\n");


            Console.WriteLine("2 - Itens a venda dada uma palavra chave e uma categoria");
            cat = "Instrumentos Musicais";
            String palChave = "yamaha";

            var consulta2 = context.Produtos
                            .Where(p => p.Estado == StatusProduto.Status.Disponivel)
                            .Where(p => p.Categoria.ToUpper() == cat.ToUpper())
                            .Where(p => p.Name.ToUpper().Contains(palChave.ToUpper()) || p.Descricao.ToUpper().Contains(palChave.ToUpper()))
                            .Select(p => new
                            {
                                p.Name,
                                p.Descricao,
                                p.Valor,
                                p.Vendedor,
                                p.Categoria
                            });


            foreach (var p in consulta2)
            {
                Console.WriteLine("Name:{0}  Descricao:{1}  Valor:{2}  Vendedor:{3}  Categoria:{4}",
                                    p.Name, p.Descricao, p.Valor, p.Vendedor, p.Categoria);
            }

            Console.WriteLine("\n\n");


            Console.WriteLine("3 - Itens a venda dentro de uma faixa de valores");
            decimal valIni = 290.0m;
            decimal valFin = 500.0m;

            var consulta3 = context.Produtos
                            .Where(p => p.Estado == StatusProduto.Status.Disponivel)
                            .Where(p => p.Valor >= valIni && p.Valor <= valFin)
                            .Select(p => new
                            {
                                p.ProdutoId,
                                p.Name,
                                p.Descricao,
                                p.Estado,
                                p.Valor,
                                p.Vendedor,
                                p.CategoriaID
                            });

            foreach (var p in consulta3)
            {
                Console.WriteLine("ProdutoId:{0}  Name:{1}  Descricao:{2}  Estado:{3}  Valor:{4}  Vendedor:{5}  CategoriaID:{6}",
                                    p.ProdutoId, p.Name, p.Descricao,
                                    p.Estado, p.Valor, p.Vendedor, p.CategoriaID);
            }


            Console.WriteLine("\n\n");


            Console.WriteLine("4 - Itens anunciados por um determinado vendedor, agrupados pelo status da venda");
            int vend = 1;

            var consulta4 = (from p in context.Produtos
                            where p.Vendedor == vend
                            select new
                            {
                                p.Name,
                                p.Estado
                            }).OrderByDescending(e => e.Estado);

            foreach (var result in consulta4)
            {
                Console.WriteLine("VendedorID: {0}\nProduto: {1}\nStatus: {2}\n", vend, result.Name, result.Estado);
            }


            Console.WriteLine("\n\n");


            Console.WriteLine("número total de itens vendidos num período e o valor total destas vendas");
            DateTime dtIni = new DateTime(2020, 04, 01, 00, 00, 00);
            DateTime dtFin = new DateTime(2020, 05, 01, 00, 00, 00);

            var consulta5 = from p in context.Produtos
                            where p.Estado == StatusProduto.Status.Vendido
                            where p.DataVenda >= dtIni && p.DataVenda <= dtFin
                            select p.Valor;

            var consulta5_1 = from p in consulta5
                              group p by 1 into grp
                              select new
                              {
                                  quanti = grp.Count(),
                                  total = grp.Sum()
                              };


            foreach (var p in consulta5_1)
            {
                Console.WriteLine("quantidade de produtos vendidos:{0}    valor total:{1}",
                                    p.quanti, p.total);
            }

            Console.WriteLine("\n\n");

            #endregion
        }
    }
}
