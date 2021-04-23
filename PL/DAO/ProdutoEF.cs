using Entities.Interfaces;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace PL.DAO
{
    public class ProdutoEF : IProdutoDAO
    {
        private readonly SecondHandContext context;

        public ProdutoEF()
        {
            context = new SecondHandContext();
        }

        public List<VendProdStatusVenda> vendedorProdStatus()
        {
            

            return null;
            
        }
    }
}
