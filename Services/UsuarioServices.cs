using Domain.entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UsuarioServices
    {
        public UsuarioDomain ValidaAcessoServices(UsuarioDomain usuario)
        {
            return new LoginRepository().ValidaUsuarioRepository(usuario);
        }
    }
}
