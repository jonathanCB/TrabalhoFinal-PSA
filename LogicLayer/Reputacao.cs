using Entities.Models;
using System;

namespace LogicLayer
{
    public class Reputacao
    {
        public int AumentaReputacao(ApplicationUser vendedor)
        {
            //Lógica para aumento de reputação:
            if (vendedor.Reputacao <= 10)
            {
                vendedor.Reputacao += 1;
            }
            else if (vendedor.Reputacao > 10 && vendedor.Reputacao <= 50)
            {
                vendedor.Reputacao += 2;
            }
            else
            {
                vendedor.Reputacao += 3;
            }

            return vendedor.Reputacao;
        }

        public int DiminuiReputacao(ApplicationUser vendedor)
        {
            if (vendedor.Reputacao <= 10)
            {
                vendedor.Reputacao -= 1;
            }
            else if (vendedor.Reputacao > 10 && vendedor.Reputacao <= 50)
            {
                vendedor.Reputacao -= 3;
            }
            else
            {
                vendedor.Reputacao -= 4;
            }

            return vendedor.Reputacao;
        }
    }
}
