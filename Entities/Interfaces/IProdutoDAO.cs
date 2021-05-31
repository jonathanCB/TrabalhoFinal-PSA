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
        public List<Produto> ListaProdutos();
        public void NovoProduto(Produto prod);
        public List<Produto> ItensPorCategoria(String cat);
        public List<Produto> ItensPalChavCat(String palChave, String cat);
        public List<Produto> FaixaDeValores(decimal valIni, decimal valFin);
        public List<Produto> ItensPorVendedor(int vend);
        public List<ItensPorIntervaloDeTempo> ItensPorIntervaloDeTempo(DateTime dtIni, DateTime dtFin);
        public Produto ItemPorId(long vend); 
    }
}