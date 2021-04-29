
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels
{
    public class ItenPorCateg
    {
        public long ProdutoId { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Vendedor { get; set; }
        public String Categoria { get; set; }
    }
}