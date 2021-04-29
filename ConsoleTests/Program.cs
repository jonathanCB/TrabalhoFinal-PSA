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
            BusinesFacade _bll = new BusinesFacade();

            #region Todos os produtos da tabela
            
            foreach (Produto p in _bll.listaDeProdutos())
            {
                Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}  {6}",
                                    p.ProdutoId, p.Name, p.Descricao, p.Estado, p.Valor, p.UsuarioId, p.CategoriaID);
            }
            #endregion

            #region Criação de um produto
            /*Produto produtoNovo = new Produto()
            {
                Name = "Placa de video RTX 3070",
                Descricao = "Placa nvidia serie RTX",
                Categoria = "Informatica",
                DataEntrada = new DateTime(2020, 10, 10),
                Estado = StatusProduto.Status.Disponivel,
                Valor = 6300.0m,
                UsuarioId = 1
            };
            _bll.NovoProduto(produtoNovo);*/
            Console.WriteLine("\n\n");
            #endregion

            #region Consulta 1 - Itens a venda de uma determinada categoria
            Console.WriteLine("1 - Itens a venda de uma determinada categoria:\n");
            String cat = "Celular";
            Console.WriteLine("Categoria pesquisada: '{0}'\n", cat);

            foreach (Produto p in _bll.ItensPorCategoria(cat))
            {
                Console.WriteLine("Produto: {0}\nDescrição: {1}\nStatus: {2}\nValor: {3}\n" +
                                    "Categoria: {4}\n",
                                    p.Name, p.Descricao, p.Estado, p.Valor, p.Categoria);
            }
            Console.WriteLine("\n\n");
            #endregion

            #region Consulta 2 - Itens a venda dada uma palavra chave e uma categoria
            Console.WriteLine("2 - Itens a venda dada uma palavra chave e uma categoria:\n");
            cat = "TV";
            String palChave = "tv";
            Console.WriteLine("Categoria pesquisada: '{0}', Palavra chave: {1}\n", cat, palChave);

            foreach (Produto p in _bll.ItensPalChavCat(palChave, cat))
            {
                Console.WriteLine("Produto: {0}\nDescrição: {1}\nStatus: {2}\nValor: {3}\n" +
                                    "Categoria: {4}\n",
                                    p.Name, p.Descricao, p.Estado, p.Valor, p.Categoria);
            }
            Console.WriteLine("\n\n");
            #endregion

            #region Consulta 3 - itens a venda dentro de uma faixa de valores
            Console.WriteLine("3 - Itens a venda dentro de uma faixa de valores\n");
            decimal valIni = 290.0m;
            decimal valFin = 500.0m;

            var consulta3 = context.Produtos
                            .Where(p => p.Estado == StatusProduto.Status.Disponivel)
                            .Where(p => p.Valor >= valIni && p.Valor <= valFin)
                            .Select(p => new
                            {
                                p.Name,
                                p.Descricao,
                                p.Valor,
                                p.UsuarioId,
                                p.Categoria
                            });

            foreach (var p in consulta3)
            {
                Console.WriteLine("Name:{0}  Descricao:{1}  Valor:{2}  Vendedor:{3}  Categoria:{4}",
                                    p.Name, p.Descricao, p.Valor, p.UsuarioId, p.Categoria);
            }


            Console.WriteLine("\n\n");


            Console.WriteLine("4 - Itens anunciados por um determinado vendedor = 1, agrupados pelo status da venda");
            int vend = 1;

            var consulta4 = (from p in context.Produtos
                             where p.UsuarioId == vend
                             select new
                             {
                                 p.Name,
                                 p.Estado
                             }).OrderByDescending(e => e.Estado);

            foreach (var result in consulta4)
            {
                Console.WriteLine("VendedorID: {0}\nProduto: {1}\nEstado: {2}\n",
                                    vend, result.Name, result.Estado);
            }

            Console.WriteLine("\n\n");


            Console.WriteLine("número total de itens vendidos num período e o valor total destas vendas = 2020,04,01 a 2020,05,01");
            DateTime dtIni = new DateTime(2020, 04, 01);
            DateTime dtFin = new DateTime(2020, 05, 01);

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

            ProdutoEF _prods = new ProdutoEF();

            var resultadoo = _prods.ItenCategorias("Celular");

            foreach (var p in resultadoo)
            {
                Console.WriteLine(p.Descricao);
            }
        }
    }
}