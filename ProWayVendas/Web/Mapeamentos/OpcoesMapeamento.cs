using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Entidades;

namespace Web.Mapeamentos
{
    public class OpcoesMapeamento : IEntityTypeConfiguration<Opcoes>
    {
        public void Configure(EntityTypeBuilder<Opcoes> builder)
        {
            builder.ToTable("opcoes");

            builder.HasKey(opcoes => opcoes.Id);

            builder.Property(opcoes => opcoes.Nome)
                .IsRequired()
                .HasMaxLength(45);
        }
    }
}
