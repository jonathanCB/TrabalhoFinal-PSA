using Entities.Interfaces;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Entities.Models;

namespace PL.DAO
{
    public class ProdutoEF : IProdutoDAO
    {
        private readonly SecondHandContext context;

        public ProdutoEF()
        {
            context = new SecondHandContext();
        }

        public List<VendProdStatusVenda> VendedorProdStatus()
        {


            return null;

        }

        //Listar todos os produtos do banco:
        public List<Produto> ListaProdutos()
        {
            List<Produto> prod = context.Produtos.ToList();
            //List<Categoria> cate = context.Categorias.ToList();
            return prod;
        }

        //Recebendo um novo produto e salvando no BD.               
        public void NovoProduto(Produto prod)
        {
            context.Produtos.Add(prod);
            context.SaveChanges();
        }

        //Consulta 1
        public List<Produto> ItensPorCategoria(String cat)
        {
            var consulta1 = context.Produtos
                            .Where(p => p.Categoria.ToUpper() == cat.ToUpper())
                            .Select(p => p);

            return consulta1.ToList();
        }

        //Consulta 2
        public List<Produto> ItensPalChavCat(String palChave, String cat)
        {
            var consulta2 = context.Produtos
                            .Where(p => p.Categoria.ToUpper() == cat.ToUpper())
                            .Where(p => p.Name.ToUpper().Contains(palChave.ToUpper()) || p.Descricao.ToUpper().Contains(palChave.ToUpper()))
                            .Select(p => p);

            return consulta2.ToList();
        }

        //Consulta 3
        public List<Produto> FaixaDeValores(decimal valIni, decimal valFin)
        {
            var consulta3 = context.Produtos
                            .Where(p => p.Estado == StatusProduto.Status.Disponivel)
                            .Where(p => p.Valor >= valIni && p.Valor <= valFin)
                            .Select(p => p);
            return consulta3.ToList();
        }

        //Consulta 4
        public List<Produto> ItensPorVendedor(int vend)
        {
            var consulta4 = context.Produtos
                            .Where(p => p.UsuarioId == vend)
                            .Select(p => p).OrderByDescending(e => e.Estado);
            return consulta4.ToList();
        }

        //Consulta 5
        public List<Produto> ItensPorIntervaloDeTempo(DateTime dtIni, DateTime dtFin)
        {

            var consulta5_0 = from p in context.Produtos
                            where p.Estado == StatusProduto.Status.Vendido
                            where p.DataVenda >= dtIni && p.DataVenda <= dtFin
                            select p.Valor;

            var consulta5_1 = from p in consulta5_0
                              group p by 1 into grp
                              select new
                              {
                                  quanti = grp.Count(),
                                  total = grp.Sum()
                              };
        }
    }
}