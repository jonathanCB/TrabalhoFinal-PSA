using Entities.Interfaces;
using LogicLayer;
using Entities.Models;
using Entities.Models.Enums;
using PL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.DAO
{
    public class ApplicationUserEF : IApplicationUserDAO
    {
        private readonly SecondHandContext _context;
        private readonly Reputacao _rep;

        //construtor produtos entity framework        

        public ApplicationUserEF(SecondHandContext context,
                                 Reputacao reputacao)
        {
            _context = context;
            _rep = reputacao;
        }

        //recebe o username e retorna o id de usuario
        public string getUserID(string userName)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName.Equals(userName));
            return user.Id;
        }

        //recebe o id de usuario e retorna informacaoes do seu perfil
        public ApplicationUser PerfilVendedor(String userName)
        {
            var vendedor = _context.ApplicationUser
                .Where(u => u.UserName.Equals(userName))
                .FirstOrDefault();

            var produtos = from p in _context.Produtos
                           where p.NomeVendedor.Equals(vendedor.UserName)
                           select p;

            int qtdDeProdutosAVenda = QtdProdutosAVenda(vendedor, produtos);
            int qtdDeProdutosAguardandoAprovacao = QtdProdutosAguardandoAprovacao(vendedor, produtos);
            int qtdDeProdutosVendidos = QtdProdutosVendidos(vendedor, produtos);
            int qtdDeProdutosEmRotaDeEntrega = QtdProdutosEmRotaDeEntrega(vendedor, produtos);
            int qtdDeProdutosEntregues = QtdProdutosEntregues(vendedor, produtos);
            int qtdDeProdutosBloqueados = QtdProdutosBloqueados(vendedor, produtos);

            return vendedor;
        }

        //conta a quantidade de produtos a venda e atualiza no bando de dados
        public int QtdProdutosAVenda(ApplicationUser vendedor, IQueryable<Produto> prod)
        {
            var produtos = from p in prod
                            where p.Estado == StatusProduto.Disponivel
                            select new
                            {
                                p.Name
                            };

            int qtdProdutosAVenda = produtos.Count();
            vendedor.ProdutosAVenda = qtdProdutosAVenda;

            _context.Update(vendedor);
            _context.SaveChanges();

            return qtdProdutosAVenda;
        }

        //conta a quantidade de produtos aguardando aprovacao e atualiza no bando de dados
        public int QtdProdutosAguardandoAprovacao(ApplicationUser vendedor, IQueryable<Produto> prod)
        {
            var produtos = from p in prod
                           where p.Estado == StatusProduto.Aguardando_Aprovacao
                           select new
                           {
                               p.Name
                           };

            int qtdProdutosAguardandoAprovacao = produtos.Count();
            vendedor.ProdutosAguardandoApVenda = qtdProdutosAguardandoAprovacao;

            _context.Update(vendedor);
            _context.SaveChanges();

            return qtdProdutosAguardandoAprovacao;
        }

        //conta a quantidade de produtos vendidos e atualiza no bando de dados
        public int QtdProdutosVendidos(ApplicationUser vendedor, IQueryable<Produto> prod)
        {
            var produtos = from p in prod
                           where p.Estado == StatusProduto.Vendido
                           select new
                           {
                               p.Name
                           };

            int qtdProdutosVendidos = produtos.Count();
            vendedor.ProdutosVendido = qtdProdutosVendidos;

            _context.Update(vendedor);
            _context.SaveChanges();

            return qtdProdutosVendidos;
        }

        //conta a quantidade de produtos em rota de entrega e atualiza no bando de dados
        public int QtdProdutosEmRotaDeEntrega(ApplicationUser vendedor, IQueryable<Produto> prod)
        {
            var produtos = from p in prod
                           where p.Estado == StatusProduto.Em_Rota_De_Entrega
                           select new
                           {
                               p.Name
                           };

            int qtdProdutosEmRotaDeEntrega = produtos.Count();
            vendedor.ProdutosEmRotaDeEntrega = qtdProdutosEmRotaDeEntrega;

            _context.Update(vendedor);
            _context.SaveChanges();

            return qtdProdutosEmRotaDeEntrega;
        }

        //conta a quantidade de produtos entregues e atualiza no bando de dados
        public int QtdProdutosEntregues(ApplicationUser vendedor, IQueryable<Produto> prod)
        {
            var produtos = from p in prod
                           where p.Estado == StatusProduto.Entregue
                           select new
                           {
                               p.Name
                           };

            int qtdProdutosEntregues = produtos.Count();
            vendedor.ProdutosEntregue = qtdProdutosEntregues;

            _context.Update(vendedor);
            _context.SaveChanges();

            return qtdProdutosEntregues;
        }

        //conta a quantidade de produtos bloqueados e atualiza no bando de dados
        public int QtdProdutosBloqueados(ApplicationUser vendedor, IQueryable<Produto> prod)
        {
            var produtos = from p in prod
                           where p.Estado == StatusProduto.Bloqueado
                           select new
                           {
                               p.Name
                           };

            int qtdProdutosBloqueados = produtos.Count();

            vendedor.ProdutosBloqueado = qtdProdutosBloqueados;

            _context.Update(vendedor);
            _context.SaveChanges();

            return qtdProdutosBloqueados;
        }

        //chama a logica da reputacao e aumenta a reputação do vendedor
        public bool AumentaRep(string userName)
        {
            var vendedor = _context.ApplicationUser
                .Where(u => u.UserName.Equals(userName))
                .FirstOrDefault();

            if (vendedor != null)
            {
                vendedor.Reputacao = _rep.AumentaReputacao(vendedor);
                _context.Update(vendedor);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        //chama a logica da reputacao e diminui a reputação do vendedor
        public bool DiminuiRep(string userName)
        {
            var vendedor = _context.ApplicationUser
                .Where(u => u.UserName.Equals(userName))
                .FirstOrDefault();

            if (vendedor != null)
            {
                vendedor.Reputacao = _rep.DiminuiReputacao(vendedor);
                _context.Update(vendedor);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
