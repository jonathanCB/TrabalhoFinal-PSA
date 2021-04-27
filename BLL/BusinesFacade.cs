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

        public List<VendProdStatusVenda> RelProdStatus(int id)
        {
            return null;
        }

        public List<ItenPorCateg> RelItenPorCateg(String id)
        {
            return dao.ItenCategorias(id);
        }
    }
}