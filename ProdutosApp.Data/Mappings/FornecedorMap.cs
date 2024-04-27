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
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            
            builder.ToTable("FORNECEDOR");            
            builder.HasKey(f => f.Id);            
            builder.Property(f => f.Id)
            .HasColumnName("ID");            
            builder.Property(f => f.RazaoSocial)
            .HasColumnName("RAZAOSOCIAL")
            .HasMaxLength(100)
            .IsRequired();            
            builder.Property(f => f.Cnpj)
            .HasColumnName("CNPJ")
            .HasMaxLength(20)
            .IsRequired();            
            builder.HasIndex(f => f.Cnpj)
            .IsUnique();
        }
    }
}
