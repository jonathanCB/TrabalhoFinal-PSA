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

        //"itens a venda de uma determinada categoria"
        public List<ItenPorCateg> ItenCategorias(String cat) 
        {
            IEnumerable<ItenPorCateg> consulta1 = (IEnumerable<ItenPorCateg>)context.Produtos
                        .Where(p => p.Estado == StatusProduto.Status.Disponivel)
                        .Where(p => p.Categoria.ToUpper() == cat.ToUpper())
                        .Select(p => new
                        {
                            p.ProdutoId,
                            p.Name,
                            p.Descricao,
                            p.Valor,
                            p.Vendedor,
                            p.Categoria
                        });

            return consulta1.ToList();
        }

    }
}
