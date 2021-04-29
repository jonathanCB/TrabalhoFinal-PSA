using Entities.Interfaces;
using Entities.Models;
using Entities.ViewModels;
using PL;
using PL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BusinesFacade
    {
        private readonly IProdutoDAO dao;

        public BusinesFacade()
        {
            this.dao = new ProdutoEF();
        }

        /*public List<VendProdStatusVenda> RelProdStatus(int id)
        {
            return null;
        }*/

        //Todos os produtos do banco:
        public List<Produto> listaDeProdutos()
        {
            return dao.ListaProdutos();
        }

        //Mandar um produto para o ProdutoEF na camada de persistência e salvar no banco
        public void NovoProduto(Produto prod)
        {
            dao.NovoProduto(prod);
        }

        //Consulta 1
        public List<Produto> ItensPorCategoria(String cat)
        {
            return dao.ItensPorCategoria(cat);
        }

        public List<Produto> ItensPalChavCat(String palChave, String cat)
        {
            return dao.ItensPalChavCat(palChave, cat);
        }
    }
}