using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Produto
    {
        public enum Status
        {
            Disponivel = 0, Vendido = 1
        }
        public int ProdutoId { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public Status Estado { get; set; }
        public decimal Valor { get; set; }
        public int Vendedor { get; set; }
        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
