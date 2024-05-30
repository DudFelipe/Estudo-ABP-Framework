using AbpFramework.Estudo.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpFramework.Estudo.EntityFrameworkCore.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Seq_Produt");
            builder.Property(p => p.Nome).HasColumnName("Des_Nome").IsRequired().HasMaxLength(ProdutoConsts.Pro_NomeMaxLength);
            builder.Property(p => p.Preco).HasColumnName("Val_Preco").IsRequired();
            builder.Property(p => p.Descricao).HasColumnName("Des_Descri");

            //Relacionamento com Categoria
            builder.HasOne(p => p.Categoria)
                   .WithMany(c => c.Produtos)
                   .HasForeignKey(p => p.CategoriaId)
                   .HasPrincipalKey(p => p.Id)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
