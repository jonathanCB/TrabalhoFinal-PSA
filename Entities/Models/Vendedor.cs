using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Usuario
    {

        public int UsuarioId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}