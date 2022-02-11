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
    public class CarroConfiguration : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.ToTable("Carro");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao).IsRequired().HasColumnName("Descricao").HasMaxLength(400);

            builder.Property(p => p.Placa).IsRequired().HasColumnName("Placa").HasMaxLength(7);
        }
    }
}
