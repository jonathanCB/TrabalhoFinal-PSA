using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Vendedor
    {
        public int VendedorId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}