using Entities.Interfaces;
using Entities.Models;
using Entities.Models.Enums;
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
            prod.Estado = StatusProduto.Disponivel;

            _context.Produtos.Add(prod);
            _context.SaveChanges();
        }

        //recebe um produto e salva as modificacoes
        public void editProduto(Produto prod)
        {
            _context.Update(prod);
            _context.SaveChanges();
        }

        //realiza a venda de um produto
        public Boolean VendaProduto(long id, String userName)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName.Equals(userName));

            var consulta1 = _context.Produtos
                            .FirstOrDefault(m => m.ProdutoId == id);

            if (consulta1 != null && consulta1.Estado == StatusProduto.Disponivel)
            {
                consulta1.NomeComprador = user.UserName;
                consulta1.UsuarioIDComprador = user.Id;
                consulta1.Estado = StatusProduto.Aguardando_Aprovacao;
                consulta1.DataVenda = DateTime.Now;
                _context.Update(consulta1);
                _context.SaveChanges();
                return true;
            }                
            
            return false;
        }

        //Comprador realiza o cancelamento da venda de um produto
        public Boolean CompradorCancelarVendaProduto(long id)
        {
            var consulta1 = _context.Produtos
                            .FirstOrDefault(m => m.ProdutoId == id);

            if (consulta1 != null && consulta1.Estado == StatusProduto.Aguardando_Aprovacao)
            {
                consulta1.NomeComprador = null;
                consulta1.UsuarioIDComprador = null;
                consulta1.Estado = StatusProduto.Disponivel;
                consulta1.DataVenda = null;
                _context.Update(consulta1);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        //Comprador aceitou realizar a venda do produto, recebe um id e muda o status do produto
        public Boolean CompradoAceitouVendaProduto(long id)
        {
            var consulta1 = _context.Produtos
                            .FirstOrDefault(m => m.ProdutoId == id);

            if (consulta1 != null && consulta1.Estado == StatusProduto.Aguardando_Aprovacao)
            {
                consulta1.Estado = StatusProduto.Vendido;
                _context.Update(consulta1);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        //Comprador negou realizar a venda do produto, recebe um id e muda o status do produto
        public Boolean CompradoNegouVendaProduto(long id)
        {
            var consulta1 = _context.Produtos
                            .FirstOrDefault(m => m.ProdutoId == id);

            //Pegando nome do vendedor que terá a reputação diminuida devido ao cancelamento da venda
            var nomeVendedor = _context.Produtos
                .Where(p => p.ProdutoId == id)
                .Select(p => p.NomeVendedor)
                .FirstOrDefault();

            //Pegando a entidade ApplicationUser relacionada ao vendedor:
            var vendedor = _context.ApplicationUser
                .Where(u => u.UserName.Equals(nomeVendedor))
                .FirstOrDefault();

            if (consulta1 != null && consulta1.Estado == StatusProduto.Aguardando_Aprovacao)
            {
                //Lógica para reputação:
                if (vendedor.Reputacao <= 5)
                {
                    vendedor.Reputacao -= 1; 
                    if (vendedor.Reputacao <= 0)
                    {
                        vendedor.Reputacao = 0;
                    }
                }
                _context.Update(vendedor);

                consulta1.Estado = StatusProduto.Bloqueado;
                _context.Update(consulta1);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        //relatorio de itens disponiveis para venda
        public List<Produto> ItensDisponiveis()
        {
            var consulta1 = _context.Produtos
                            .Where(p => p.Estado == StatusProduto.Disponivel)
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
                                        .Where(p => p.Estado == StatusProduto.Disponivel)
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
                            .Where(x => x.Estado == StatusProduto.Disponivel)
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
                            .Where(p => p.Estado == StatusProduto.Disponivel)
                            .Where(p => p.Name.ToUpper().Contains(palChave.ToUpper()))
                            .Select(p => p);

            return consulta2;
        }

        //recebe dois valores e retorna uma lista de produtos dentro desses valores
        public List<Produto> ItensFaixaDeValores(decimal valIni, decimal valFin)
        {
            var consulta3 = _context.Produtos
                            .Where(p => p.Estado == StatusProduto.Disponivel)
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
                            where p.Estado == StatusProduto.Vendido
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

        //recebe um id do comprador e retorna uma lista de todos os produtos
        //comprados por ele ordenados pelo status
        public List<Produto> ItensDoComprador(String usu)
        {
            var consulta4 = _context.Produtos
                            .Where(p => p.UsuarioIDComprador == usu)
                            .Select(p => p).OrderByDescending(e => e.Estado);

            return consulta4.ToList();
        }

        //retorna uma lista de produtos prontos para serem entregados
        public List<Produto> ItensParaEntrega()
        {
            var consulta4 = _context.Produtos
                            .Where(p => p.Estado == StatusProduto.Vendido)
                            .Where(p => p.NomeComprador != null)
                            .Select(p => p).OrderByDescending(e => e.Name);

            return consulta4.ToList();
        }

        //retorna uma lista de produtos em rota de entrega
        public List<Produto> ItensEmRotaDeEntrega()
        {
            var consulta4 = _context.Produtos
                            .Where(p => p.Estado == StatusProduto.Em_Rota_De_Entrega)
                            .Where(p => p.NomeComprador != null)
                            .Select(p => p).OrderByDescending(e => e.Name);

            return consulta4.ToList();
        }

        //recebe o id de um produto e confirma sua entrega
        public Boolean ProdutoEntregue(long id)
        {
            var consulta1 = _context.Produtos
                            .FirstOrDefault(m => m.ProdutoId == id);

            //Pegando nome do vendedor que terá a reputação aumentada:
            var nomeVendedor = _context.Produtos
                .Where(p => p.ProdutoId == id)
                .Select(p => p.NomeVendedor)
                .FirstOrDefault();

            //Pegando a entidade ApplicationUser relacionada ao vendedor:
            var vendedor = _context.ApplicationUser
                .Where(u => u.UserName.Equals(nomeVendedor))
                .FirstOrDefault();

            if (consulta1 != null)
            {
                consulta1.Estado = StatusProduto.Entregue;

                //Lógica para reputação:
                if (vendedor.Reputacao <= 5) 
                { 
                    vendedor.Reputacao += 2;
                    if (vendedor.Reputacao > 5)
                    {
                        vendedor.Reputacao = 5;
                    }
                }
                _context.Update(vendedor);

                _context.Update(consulta1);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        //recebe o id de um produto e o email de um entregador e coloca o produto
        //para rota de entregada
        public Boolean EntregaProduto(long id, String entregador)
        {
            var consulta1 = _context.Produtos
                           .FirstOrDefault(m => m.ProdutoId == id);

            if (consulta1 != null)
            {
                consulta1.Estado = StatusProduto.Em_Rota_De_Entrega;
                consulta1.NomeEntregador = entregador;
                _context.Update(consulta1);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
