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

        //"2.1 - Itens a venda de uma determinada categoria"
        public List<Produto> ItenCategorias(String cat)
        {
            var consulta1 = context.Produtos
                         .Where(p => p.Estado == StatusProduto.Status.Disponivel)
                         .Where(p => p.Categoria.ToUpper() == cat.ToUpper())
                         .Select(p => p);

            return consulta1.ToList();
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
    }
}