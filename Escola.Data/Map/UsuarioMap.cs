using Escola.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Senha).HasColumnType("varchar(20)")
                .IsRequired();

            // builder.Property(x => x.Token).HasColumnType("varchar(MAX)");

            builder.Property(x => x.Perfil).HasColumnType("varchar(100)");
        }
    }
}
