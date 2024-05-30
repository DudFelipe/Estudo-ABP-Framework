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
    public class ImagemProdutoConfiguration : IEntityTypeConfiguration<ImagemProduto>
    {
        public void Configure(EntityTypeBuilder<ImagemProduto> builder)
        {
            builder.ToTable("ImagensProdutos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnName("Des_Nome").IsRequired();
            builder.Property(x => x.Path).HasColumnName("Des_Path").IsRequired();

            //Relacionamento com Produto
            builder.HasOne(i => i.Produto)
                .WithMany(p => p.Imagens)
                .HasForeignKey(i => i.ProdutoId)
                .HasPrincipalKey(i => i.Id);
        }
    }
}
