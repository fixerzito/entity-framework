using Microsoft.EntityFrameworkCore;
using Web.Entidades;
using Web.Mapeamentos;

namespace Web.BancoDados
{
    public class VendasContexto : DbContext
    {
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Opcoes> Opcoes { get; set; }

        //Intalar cli do .net interface
        //dotnet tool install --global dotnet-ef

        //como gerar migration
        // dotnet ef migrations add <NomeMgracao>
        // Ex: dotnet ef migrations add CriarTabelaCores

        //Atualizar o banco de dados aplicando as migrations
        // dotnet ef database update

        // Migration é um snapshot do vódito referente as tabelas do banco de dados

        public VendasContexto(DbContextOptions options) : base(options)
        { 
            
        }

        //code FIrst: do codigo sera gerado o banco de dados
        //database first: do banco de dados serpa gerado de codigo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CorMapeamento());
            modelBuilder.ApplyConfiguration(new OpcoesMapeamento());
        }
    }
}
