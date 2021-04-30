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


            #region Criação

            Produto produtoNovo = new Produto()
            {
                Name = "prod teste",
                Descricao = "produto para testar a criação no bando de dados",
                Categoria = "Tv",
                DataEntrada = new DateTime(2020, 04, 01),
                Estado = StatusProduto.Status.Disponivel,
                Valor = 200.0m,
                UsuarioID = 1
            };

            _bll.CadNovoProduto(produtoNovo);

            #endregion


            #region testando conteudo de cada "tabela"

            List<Categoria> cate = context.Categorias.ToList();

            foreach (Categoria c in cate)
            {
                Console.WriteLine("{0}  {1}",
                                    c.CategoriaId, c.Name);
            }
            Console.WriteLine("\n\n");

            foreach (Produto p in _bll.ListaDeProdutos())
            {
                Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}  {6}",
                                    p.ProdutoId, p.Name, p.Descricao, p.Estado, 
                                    p.Valor, p.UsuarioID, p.Categoria);
            }
            Console.WriteLine("\n\n");

            #endregion


            #region Testando todas as consultas da entrega 1

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

            
            Console.WriteLine("3 - Itens a venda dentro de uma faixa de valores\n");
            decimal valIni = 290.0m;
            decimal valFin = 500.0m;
            Console.WriteLine("Faixa de valores\nDe: [{0}] a: [{1}]\n", valIni, valFin);

            foreach (Produto p in _bll.ItensFaixaDeValores(valIni, valFin))
            {
                Console.WriteLine("Produto: {0}\nDescrição: {1}\nStatus: {2}\nValor: {3}\n" +
                                    "Categoria: {4}\n",
                                    p.Name, p.Descricao, p.Estado, p.Valor, p.Categoria);
            }
            Console.WriteLine("\n\n");            

            
            Console.WriteLine("4 - Itens anunciados por um determinado vendedor agrupados pelo status da venda\n");
            int vend = 2;
            Console.WriteLine("ID do vendedor: {0}\n", vend);

            foreach (Produto p in _bll.ItensPorStatusUsu(vend))
            {
                Console.WriteLine("Produto: {0}\nDescrição: {1}\nStatus: {2}\nValor: {3}\n" +
                                    "Categoria: {4}\n",
                                    p.Name, p.Descricao, p.Estado, p.Valor, p.Categoria);
            }
            Console.WriteLine("\n\n");            

            
            Console.WriteLine("5 - Número total de itens vendidos num período e o valor total destas vendas\n");
            DateTime dtIni = new DateTime(2020, 04, 01);
            DateTime dtFin = new DateTime(2020, 05, 01);
            Console.WriteLine("Entre as datas de '{0}' e '{1}'\n", dtIni, dtFin);

            foreach (String p in _bll.TotalVendaPeriodo(dtIni, dtFin))
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("\n\n");

            #endregion

        }
    }
}
