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

        //construtor produtos entity framework
        public ProdutoEF()
        {
            context = new SecondHandContext();
        }

        //recebe um produto novo e salva no bando de dados
        public void CadastroNovoProduto(Produto prod)
        {
            context.Produtos.Add(prod);
            context.SaveChanges();
        }

        //retorna uma lista com todos os produtos no bando de dados
        public List<Produto> ListaDeProdutos()
        {
            List<Produto> prod = context.Produtos.ToList();
            return prod;
        }

        //recebe uma categoria e retorna todos os produtos dessa categoria
        public List<Produto> ItensPorCategoria(string cat)
        {
            var consulta1 = context.Produtos
                            .Where(p => p.Categoria.ToUpper() == cat.ToUpper())
                            .Select(p => p);

            return consulta1.ToList();
        }

        //recebe uma categoria e uma palavra chave e retorna uma lista desses produtos
        public List<Produto> ItensPalChavCat(string palChave, string cat)
        {
            var consulta2 = context.Produtos
                            .Where(p => p.Categoria.ToUpper() == cat.ToUpper())
                            .Where(p => p.Name.ToUpper().Contains(palChave.ToUpper()) || p.Descricao.ToUpper().Contains(palChave.ToUpper()))
                            .Select(p => p);

            return consulta2.ToList();
        }

        //recebe dois valores e retorna uma lista de produtos dentro desses valores
        public List<Produto> ItensFaixaDeValores(decimal valIni, decimal valFin)
        {
            var consulta3 = context.Produtos
                            .Where(p => p.Estado == StatusProduto.Status.Disponivel)
                            .Where(p => p.Valor >= valIni && p.Valor <= valFin)
                            .Select(p => p);

            return consulta3.ToList();
        }

        //recebe um id de usuario e retorna uma lista de todos os produtos ordenados pelo status
        public List<Produto> ItensPorStatusUsu(long usu)
        {
            var consulta4 = context.Produtos
                            .Where(p => p.UsuarioID == usu)
                            .Select(p => p).OrderByDescending(e => e.Estado);

            return consulta4.ToList();
        }

        //recebe duas datas e retorna o numero de itens vendidos
        //bem como o total da soma do valor desses produtos
        public List<String> NroTotalVendaPeriodo(DateTime dtIni, DateTime dtFin)
        {
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
            List<String> result = new List<string>();

            foreach(var elem in consulta5_1)
            {
                result.Add("Quantidade de produtos vendidos: " + elem.quanti + "\n" + 
                           "Valor total dos itens vendidos: " + elem.total);
            }

            return result;
        }
    }
}
