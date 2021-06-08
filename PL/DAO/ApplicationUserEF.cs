using Entities.Interfaces;
using Entities.Models;
using Entities.Models.Enums;
using Entities.ViewModels;
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

        //construtor produtos entity framework        

        public ApplicationUserEF(SecondHandContext context)
        {
            _context = context;
        }    

        public string getUserID(string userName)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName.Equals(userName));
            return user.Id;
        }
        public ApplicationUser PerfilVendedor(long id)
        {
            var nomeVendedor = _context.Produtos
                .Where(p => p.ProdutoId == id)
                .Select(p => p.NomeVendedor)
                .FirstOrDefault();
            
            var vendedor = _context.ApplicationUser
                .Where(u => u.UserName.Equals(nomeVendedor))
                .FirstOrDefault();

            int qtdDeProdutosAVenda = QtdProdutosAVenda(vendedor);
            int qtdDeProdutosAguardandoAprovacao = QtdProdutosAguardandoAprovacao(vendedor);

            return vendedor;
        }

        public int QtdProdutosAVenda(ApplicationUser vendedor)
        {
            /*
             * Consultando os produtos com determinado vendedor, onde
             * o status é 'Disponivel':
             */
            var produtos = from p in _context.Produtos
                                    where p.NomeVendedor.Equals(vendedor.UserName)
                                    where p.Estado == StatusProduto.Disponivel
                                    select new
                                    {
                                        p.Name
                                    };

            //Pegando a quantidade de produtos da consulta:
            int qtdProdutosAVenda = produtos.Count();

            /*
             * Setando a qtd de produtos a venda desse vendedor
             * com a qtd de produtos encontrados na consulta:
             */
            vendedor.ProdutosAVenda = qtdProdutosAVenda;

            //Atualizando o vendedor no banco:
            _context.Update(vendedor);

            //Salvando as novas informações do vendedor no banco:
            _context.SaveChanges();

            return qtdProdutosAVenda;
        }

        public int QtdProdutosAguardandoAprovacao(ApplicationUser vendedor)
        {
            /*
             * Consultando os produtos com determinado vendedor, onde
             * o status é 'Aguardando aprovacao':
             */
            var produtos = from p in _context.Produtos
                           where p.NomeVendedor.Equals(vendedor.UserName)
                           where p.Estado == StatusProduto.Aguardando_Aprovacao
                           select new
                           {
                               p.Name
                           };

            //Pegando a quantidade de produtos da consulta:
            int qtdProdutosAguardandoAprovacao = produtos.Count();

            /*
             * Setando a qtd de produtos aguardando aprovacao desse vendedor
             * com a qtd de produtos encontrados na consulta:
             */
            vendedor.ProdutosAguardandoApVenda = qtdProdutosAguardandoAprovacao;

            //Atualizando o vendedor no banco:
            _context.Update(vendedor);

            //Salvando as novas informações do vendedor no banco:
            _context.SaveChanges();

            return qtdProdutosAguardandoAprovacao;
        }
    }
}
