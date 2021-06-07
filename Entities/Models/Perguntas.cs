using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Perguntas
    {
        [Required]
        public long PerguntasId { get; set; }

        [Required]
        public String Pergunta { get; set; }
        
        public String Resposta { get; set; }

        [Required]
        public StatusPergunta StatusPergunta { get;set;}

        [Required]
        public long ProdutoId { get; set; }

        public Produto Produto { get; set; }
    }
}
