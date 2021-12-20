using Domain.Contracts.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public class UsuarioRepositoryEF : RepositoryEF<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositoryEF(DataContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<Usuario>> GetByNomeUsuario(string name)
        {
            return await _db.Where(x => x.UserName.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetLogado(string userName, string password)
        {
          return  _db.Where(x => x.UserName.ToLower() == userName.ToLower() && x.Password.ToString() == password.ToString());
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {

            return await _db.ToListAsync();
        }

        public Task<List<Usuario>> GetUsuariosList()
        {
            return  _db.ToListAsync();
        }
    }
}
