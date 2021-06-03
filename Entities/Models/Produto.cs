using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Required]
        public Status Estado { get; set; }

        [Required]
        [Display(Name = "Valor do Produto")]
        public decimal Valor { get; set; }

        [Display(Name = "Data de Anuncio")]
        [DataType(DataType.Date)]
        public DateTime DataEntrada { get; set; }

        [Display(Name = "Data da Venda")]
        [DataType(DataType.Date)]
        public DateTime? DataVenda { get; set; }

        [Required]
        [Display(Name = "ID do Usuario Vendedor")]
        public String UsuarioIDVendedor { get; set; }

        [Required]
        [Display(Name = "Email do Vendedor")]
        public String NomeVendedor { get; set; }

        [Display(Name = "ID do Usuario Comprador")]
        public String UsuarioIDComprador { get; set; }
                
        [Display(Name = "Nome do Comprador")]
        public String NomeComprador { get; set; }

        [Display(Name = "ID do Usuario Entregador")]
        public String UsuarioIDEntregador { get; set; }

        [Display(Name = "Nome do Comprador")]
        public String NomeEntregador { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Imagem> Imagens { get; set; }

    }
}
