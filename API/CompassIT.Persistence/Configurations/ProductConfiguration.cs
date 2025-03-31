using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompassIT.Domain.Entities;

namespace CompassIT.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                   .HasColumnType("NVARCHAR(100)")
                   .IsRequired();

            builder.Property(p => p.Preco)
                   .HasColumnType("DECIMAL(18,2)")
                   .IsRequired(); 

            builder.Property(p => p.Quantidade)
                   .HasColumnType("INT")
                   .IsRequired(); 
        }
    }
}
