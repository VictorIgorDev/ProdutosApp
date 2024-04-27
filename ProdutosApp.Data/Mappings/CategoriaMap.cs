using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            
            builder.ToTable("CATEGORIA");            
            builder.HasKey(c => c.Id);            
            builder.Property(c => c.Id)
            .HasColumnName("ID");            
            builder.Property(c => c.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(50)
            .IsRequired();            
            builder.HasIndex(c => c.Nome)
            .IsUnique();
        }
    }
}
