using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using static Entities.Models.StatusProduto;

namespace Entities.Models
{
    public class Produto
    {

        [Required]
        [Display(Name = "ID do Produto")]
        public long ProdutoId { get; set; }

        [Required]
        [Display(Name = "Nome do Produto")]
        [StringLength(60, MinimumLength = 10)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descrição do Produto")]
        [StringLength(1000, MinimumLength = 10)]
        public string Descricao { get; set; }

        public Status Estado { get; set; }

        [Required]
        [Display(Name = "Valor do Produto")]
        public decimal Valor { get; set; }

        [Display(Name = "Data de Anuncio")]
        public DateTime DataEntrada { get; set; }

        [Display(Name = "Data da Venda")]
        public DateTime? DataVenda { get; set; }

        public long Vendedor { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public String Categoria { get; set; }

        public virtual Categoria CategoriaID { get; set; }
    }
}