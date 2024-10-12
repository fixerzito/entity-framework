using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Entidades;

namespace Web.Mapeamentos
{
    public class CorMapeamento : IEntityTypeConfiguration<Cor>
    {
        //dotnet tool install --global dotnet-ef
        public void Configure(EntityTypeBuilder<Cor> builder)
        {
            //definir qual ser ao nome da tabela no banco de dados
            builder.ToTable("cores");

            //definir qual chave primaria sera usada
            builder.HasKey(cor => cor.Id);

            builder.Property(cor => cor.Nome).
                IsRequired() //definindo que a colua é NN
                .HasMaxLength(45);
        }
    }
}
