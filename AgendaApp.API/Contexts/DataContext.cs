using AgendaApp.API.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.API.Contexts
{
    /// <summary>
    /// Classe para configuração do Entity Framework Core e acesso ao banco de dados.
    /// </summary>
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuração o provedor e o caminho de banco de dados
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDAgenda;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Adicionar cada classe de mapeamento feita no projeto
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }
    }
}
