using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Grupo
    {
        public int GrupoId { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Integrantes { get; set; }
        [Required]
        [Url]
        public String GitHub { get; set; }
        public String Comentarios { get; set; }
    }

}
