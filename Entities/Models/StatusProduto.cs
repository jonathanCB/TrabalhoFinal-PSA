
namespace Entities.Models
{
    public class StatusProduto
    {
        public enum Status
        {
            Disponivel = 0, Vendido = 1, AguardandoAprovacao = 2, EmRotaDeEntrega = 3, Entregue = 4
        }
    }
}
