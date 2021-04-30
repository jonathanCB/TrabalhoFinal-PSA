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

        //construtor busines facade
        public BusinesFacade()
        {
            this.dao = new ProdutoEF();
        }

        #region consultas em produtos

        //Todos os produtos do banco:
        public List<Produto> ListaDeProdutos()
        {
            return dao.ListaDeProdutos();
        }

        //Salva um produto novo no banco
        public void CadNovoProduto(Produto prod)
        {
            dao.CadastroNovoProduto(prod);
        }

        //relatorio de itens por uma determinada categoria
        public List<Produto> ItensPorCategoria(String cat)
        {
            return dao.ItensPorCategoria(cat);
        }

        //relatorio de itens por uma determinada categoria e palavra
        public List<Produto> ItensPalChavCat(String palChave, String cat)
        {
            return dao.ItensPalChavCat(palChave, cat);
        }

        //relatorio de itens por uma determinada faixa de valores
        public List<Produto> ItensFaixaDeValores(decimal valIni, decimal valFin)
        {
            return dao.ItensFaixaDeValores(valIni, valFin);
        }

        //relatorio de itens por um determinado usuario
        public List<Produto> ItensPorStatusUsu(long usu)
        {
            return dao.ItensPorStatusUsu(usu);
        }

        ////relatorio do total de vendas em um determinado periodo de tempo
        public List<String> TotalVendaPeriodo(DateTime dtIni, DateTime dtFin)
        {
            return dao.NroTotalVendaPeriodo(dtIni, dtFin);
        }
        #endregion

    }
}
