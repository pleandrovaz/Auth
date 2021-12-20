using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> GetByNomeUsuario(string name);
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<List<Usuario>> GetUsuariosList();
        Task<IEnumerable<Usuario>> GetLogado(string userName, string password);
                 
    }
}
