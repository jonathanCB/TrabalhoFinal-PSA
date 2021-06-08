using Entities.Models;
using System;

namespace LogicLayer
{
    public class Reputacao
    {
        public ApplicationUser AumentaReputacao(ApplicationUser vendedor)
        {
            //Lógica para aumento de reputação:
            if (vendedor.Reputacao <= 5)
            {
                vendedor.Reputacao += 2;
                if (vendedor.Reputacao > 5)
                {
                    vendedor.Reputacao = 5;
                }
            } 
            else
            {
                vendedor.Reputacao = 5;
            }
            return vendedor;
        }

        public ApplicationUser DiminuiReputacao(ApplicationUser vendedor)
        {
            if (vendedor.Reputacao <= 5)
            {
                vendedor.Reputacao -= 1;
                if (vendedor.Reputacao <= 0)
                {
                    vendedor.Reputacao = 0;
                }
            }

            return vendedor;
        }
    }
}
