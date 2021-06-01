using Entities.Interfaces;
using Entities.Models;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using PL.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PL.DAO
{
    public class ProdutoEF : IProdutoDAO
    {
        private readonly SecondHandContext _context;

        //construtor produtos entity framework        
        
        public ProdutoEF(SecondHandContext context)
        {
            _context = context;
        }        

        //Recebe um id e informa se o produto existe ou nao
        public Boolean existe(long ProdutoID)
        {
            return _context.Produtos.Any(e => e.ProdutoId == ProdutoID);
        }

        //Recebe um id e deleta o produto
        public void deletaProduto(long ProdutoID)
        {
            var produto = _context.Produtos.Find(ProdutoID);
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        //recebe um produto novo e salva no bando de dados
        public void CadastroNovoProduto(Produto prod)
        {
            prod.Estado = StatusProduto.Status.Disponivel;

            _context.Produtos.Add(prod);
            _context.SaveChanges();
        }

        //recebe um produto e salva as modificacoes
        public void editProduto(Produto prod)
        {
            _context.Update(prod);
            _context.SaveChanges();
        }

        //relatorio de itens disponiveis para venda
        public List<Produto> ItensDisponiveis()
        {
            var consulta1 = _context.Produtos
                            .Where(p => p.Estado == StatusProduto.Status.Disponivel)
                            .Select(p => p);

            return consulta1.ToList();
        }

        //recebe um id de produto e retorna o mesmo
        public Produto ItemPorId(long ProdutoID)
        {
            var consulta1 = _context.Produtos
                            .Include("Imagens")
                            .FirstOrDefault(m => m.ProdutoId == ProdutoID);

            return consulta1;
        }

        //retorna uma lista com todos os produtos no banco de dados
        public List<Produto> ListaDeProdutos()
        {
            List<Produto> prod = _context.Produtos.ToList();
            return prod;
        }

        //retorna uma lista IQuerable com todos os produtos disponiveis para venda no banco de dados
        public IQueryable<Produto> IQuerDeProdutosDisponiveis()
        {
            IQueryable<Produto> prod = _context.Produtos
                                        .Where(p => p.Estado == StatusProduto.Status.Disponivel)
                                        .Select(p => p);
            return prod;
        }

        //recebe uma categoria e retorna todos os produtos dessa categoria
        public List<Produto> ItensPorCategoria(String cat)
        {
            var consulta1 = _context.Produtos
                            .Where(x => x.Categoria.Name == cat);

            return consulta1.ToList();
        }

        //recebe uma categoria e retorna todos os produtos dessa categoria
        public IQueryable<Produto> ItensPorCategoriaDisponiveis(String cat)
        {
            var consulta1 = _context.Produtos
                            .Where(x => x.Estado == StatusProduto.Status.Disponivel)
                            .Where(x => x.Categoria.Name == cat)
                            .Select(p => p);

            return consulta1;
        }

        //recebe uma categoria e uma palavra chave e retorna uma lista desses produtos
        public List<Produto> ItensPalChavCat(string palChave, String cat)
        {
            var consulta2 = _context.Produtos
                            .Where(p => p.Categoria.Name == cat)
                            .Where(p => p.Name.ToUpper().Contains(palChave.ToUpper()) || p.Descricao.ToUpper().Contains(palChave.ToUpper()))
                            .Select(p => p);

            return consulta2.ToList();
        }

        //recebe uma palavra chave e retorna um produto
        public List<Produto> ItensPalChav(string palChave)
        {
            var consulta2 = _context.Produtos
                            .Where(p => p.Name.ToUpper().Contains(palChave.ToUpper()))
                            .Select(p => p);

            return consulta2.ToList();
        }

        //recebe uma palavra chave e retorna produtos disponiveis
        public IQueryable<Produto> ItensPalChavDisponiveis(string palChave)
        {
            var consulta2 = _context.Produtos
                            .Where(p => p.Estado == StatusProduto.Status.Disponivel)
                            .Where(p => p.Name.ToUpper().Contains(palChave.ToUpper()))
                            .Select(p => p);

            return consulta2;
        }

        //recebe dois valores e retorna uma lista de produtos dentro desses valores
        public List<Produto> ItensFaixaDeValores(decimal valIni, decimal valFin)
        {
            var consulta3 = _context.Produtos
                            .Where(p => p.Estado == StatusProduto.Status.Disponivel)
                            .Where(p => p.Valor >= valIni && p.Valor <= valFin)
                            .Select(p => p);

            return consulta3.ToList();
        }

        //recebe um id de usuario e retorna uma lista de todos os produtos ordenados pelo status
        public List<Produto> ItensPorStatusUsu(String usu)
        {
            var consulta4 = _context.Produtos
                            .Where(p => p.UsuarioIDVendedor == usu)
                            .Select(p => p).OrderByDescending(e => e.Estado);

            return consulta4.ToList();
        }

        //recebe duas datas e retorna o numero de itens vendidos
        //bem como o total da soma do valor desses produtos
        public IQueryable<TotalVendaPorPeriodo> NroTotalVendaPeriodo(DateTime dtIni, DateTime dtFin)
        {
            var consulta5 = from p in _context.Produtos
                            where p.Estado == StatusProduto.Status.Vendido
                            where p.DataVenda >= dtIni && p.DataVenda <= dtFin
                            select p.Valor;

            var consulta5_1 = from p in consulta5
                              group p by 1 into grp
                              select new TotalVendaPorPeriodo
                              {
                                  numVendasPeriodo = grp.Count(),
                                  valorVendasPeriodo = grp.Sum()
                              };            

            return consulta5_1;
        }

        //recebe um id do comprador e retorna uma lista de todos os produtos ordenados pelo status
        public List<Produto> ItensDoComprador(String usu)
        {
            var consulta4 = _context.Produtos
                            .Where(p => p.UsuarioIDComprador == usu)
                            .Select(p => p).OrderByDescending(e => e.Estado);

            return consulta4.ToList();
        }

    }
}
