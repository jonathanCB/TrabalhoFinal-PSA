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
        //private readonly SecondHandContext context;

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

        //Consulta 2
        public List<Produto> ItensPalChavCat(String palChave, String cat)
        {
            return dao.ItensPalChavCat(palChave, cat);
        }

        //Consulta 3
        public List<Produto> FaixaDeValores(decimal valIni, decimal valFin)
        {
            return dao.FaixaDeValores(valIni, valFin);
        }

        //Consulta 4
        public List<Produto> ItensPorVendedor(int vend)
        {
            return dao.ItensPorVendedor(vend);
        }

        //Consulta 5
        public List<ItensPorIntervaloDeTempo> ItensPorIntervaloDeTempo(DateTime dtIni, DateTime dtFin)
        {
            return dao.ItensPorIntervaloDeTempo(dtIni, dtFin);
        }

        //Item por id. É utilizando no método Details e no método [GET] Edit.
        public Produto ItemPorId(long id)
        {
            return dao.ItemPorId(id);
        }

        //Recebe o produto atualizado para salvar no banco.
        public void AtualizaProduto(Produto prod)
        {
            dao.AtualizaProduto(prod);
        }

        //Deletar um produto do banco.
        public void DeletaProduto(long id)
        {
            dao.DeletaProduto(id);
        }

        //Método para verificar se um produto existe.
        public bool ProdutoExiste(long id)
        {
            return dao.ProdutoExiste(id);
        }
    }
}