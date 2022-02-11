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
    public class CondutorConfiguration : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("Condutor");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Email).IsRequired().HasColumnName("Email").HasMaxLength(100);

            builder.Property(p => p.Nome).IsRequired().HasColumnName("Nome").HasMaxLength(200);
        }
    }
}
