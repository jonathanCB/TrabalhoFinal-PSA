using Entities.Models;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Entities.Interfaces
{

    public interface IProdutoDAO
    {
        public List<VendProdStatusVenda> VendedorProdStatus();
        //public List<Produto> ItenCategorias(String cat);
        public List<Produto> ListaProdutos();
        public void NovoProduto(Produto prod);
        public List<Produto> ItensPorCategoria(String cat);
        public List<Produto> ItensPalChavCat(String palChave, String cat);
    }
}