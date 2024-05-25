using AbpFramework.Estudo.Categorias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpFramework.Estudo.EntityFrameworkCore.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Seq_Catego");
            builder.Property(c => c.Nome).HasColumnName("Des_Nome").IsRequired().HasMaxLength(CategoriaConsts.Cat_NomeMaxLength);
            builder.Property(c => c.Descricao).HasColumnName("Des_Descri").IsRequired().HasMaxLength(CategoriaConsts.Cat_DescriMaxLength);

        }
    }
}
