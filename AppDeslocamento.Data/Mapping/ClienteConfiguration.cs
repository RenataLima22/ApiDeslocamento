using AppDeslocamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Data.Mapping
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Cpf).IsRequired().HasColumnName("Cpf").HasMaxLength(11);

            builder.Property(p => p.Nome).IsRequired().HasColumnName("Nome").HasMaxLength(200);
        }
    }
}
