using Entities.Models;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IApplicationUserDAO
    {
        //recebe o username e retorna o id de usuario
        public String getUserID(String userName);

        //retorna informações de vendas de um perfil
        public ApplicationUser vendasPerfil(String userName);

        //retorna informações de compras de um perfil
        public ApplicationUser comprasPerfil(String userName);

        //recebe o username e retorna o endereco e cep
        public IQueryable<EnderecoComCep> getEnderecoCep(string userName);

        //aumenta a reputação do vendedor
        public Boolean AumentaRep(String userName);

        //aumenta a reputação do vendedor
        public Boolean DiminuiRep(String userName);
    }
}
