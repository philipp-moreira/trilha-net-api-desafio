using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Tarefa>(t => 
                {
                    t.ToTable($"Tb_{nameof(Tarefa)}");
                        t.Property(p => p.Titulo).HasColumnType("nvarchar(100)");
                        t.Property(p => p.Descricao).HasColumnType("nvarchar(200)");
                });
        }
    }
}