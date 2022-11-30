using Indimin.EastView.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Indimin.EastView.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Tarea> Tareas { get; set; }

        public DbSet<Cuidadano> Cuidadanos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>().ToTable("TAREA");
            modelBuilder.Entity<Cuidadano>().ToTable("CUIDADANO");
        }
    }
}
