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
        public String getUserID(String userName);
        public ApplicationUser PerfilVendedor(long id);
    }
}
