using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public class ProdutoComImagens
    {
        public Produto produto { get; set; }

        public ICollection<Imagem> imagens { get; set; }
    }
}
