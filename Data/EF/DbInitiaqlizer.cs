using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
    public static class DbInitiaqlizer
    {
     public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
               .HasData(
               new Usuario() { Id = 1, UserName = "administrador", Password = "senha123", Role = "admin" },
               new Usuario() { Id = 2, UserName = "leandro", Password = "123456", Role = "user" }
               );

        }
    }
}
