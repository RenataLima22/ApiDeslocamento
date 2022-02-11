using AppDeslocamento.Data.Mapping;
using AppDeslocamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opcoes) : base(opcoes)
        {

        }

        public ApplicationDbContext()
        {

        }

        public DbSet<Carro> Carro { get; set; }

        public DbSet<Condutor> Condutor { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Deslocamento> Deslocamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Carro>(new CarroConfiguration().Configure);
            modelBuilder.Entity<Condutor>(new CondutorConfiguration().Configure);
            modelBuilder.Entity<Cliente>(new ClienteConfiguration().Configure);
            modelBuilder.Entity<Deslocamento>(new DeslocamentoConfiguration().Configure);

        }
    }
}
