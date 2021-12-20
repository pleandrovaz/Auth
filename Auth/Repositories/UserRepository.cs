using Auth.Models;
using Data.EF;
using Data.EF.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Repositories
{
    public class UserRepository : RepositoryEF<Usuario>
    {
        public UserRepository(DataContext ctx) : base(ctx)
        {
        }

        public  Usuario Get(string username, string password, int idade)
        {
           return _db.Where(x => x.UserName.ToLower() == username.ToLower() && x.Password.ToString() == password.ToString()).FirstOrDefault();
        }
      
    }
}
