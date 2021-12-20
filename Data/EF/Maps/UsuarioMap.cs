using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //table
            builder.ToTable(nameof(Usuario));

            //PK
            builder.HasKey(U => U.Id);

            //Colunms
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.UserName)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(u => u.Password)
                .HasColumnType("varchar(100)")
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
