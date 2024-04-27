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
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.ToTable("PRODUTO");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
            .HasColumnName("ID");
            builder.Property(p => p.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(100)
            .IsRequired();
            builder.Property(p => p.Preco)
            .HasColumnName("PRECO")
            .HasColumnType("DECIMAL(10,2)")
            .IsRequired();
            builder.Property(p => p.Quantidade)
            .HasColumnName("QUANTIDADE")
            .IsRequired();
            builder.Property(p => p.CategoriaId)
            .HasColumnName("CATEGORIA_ID")
            .IsRequired();
            builder.Property(p => p.FornecedorId)
            .HasColumnName("FORNECEDOR_ID")
            .IsRequired();
            builder.HasOne(p => p.Categoria)
            .WithMany(c => c.Produtos)
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Fornecedor)
            .WithMany(f => f.Produtos)
            .HasForeignKey(p => p.FornecedorId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
