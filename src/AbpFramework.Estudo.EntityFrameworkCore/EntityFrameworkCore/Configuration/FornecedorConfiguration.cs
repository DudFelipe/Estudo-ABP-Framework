using AbpFramework.Estudo.Fornecedores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpFramework.Estudo.EntityFrameworkCore.Configuration
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedores");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Seq_Fornec");
            builder.Property(x => x.Nome).HasColumnName("Des_Nome").IsRequired().HasMaxLength(FornecedorConsts.For_NomeMaxLength);
            builder.Property(x => x.Cnpj).HasColumnName("Num_Cnpj").IsRequired().HasMaxLength(FornecedorConsts.For_CnpjLength);
            builder.HasIndex(x => x.Cnpj).IsUnique();

            //Relacionamento com Produtos
            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId)
                .HasPrincipalKey(f => f.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
