using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public Boolean ProdutoNovo { get; set; }
        public decimal Valor { get; set; }
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
