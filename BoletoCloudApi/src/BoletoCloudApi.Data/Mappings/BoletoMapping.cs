using BoletoCloudApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoCloudApi.Data.Mappings
{
    public class BoletoMapping : IEntityTypeConfiguration<Boleto>
    {
        public void Configure(EntityTypeBuilder<Boleto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Numero)
                .IsRequired()
                .HasColumnType("varchar(20)"); 

            builder.Property(x => x.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)"); 
           
            builder.Property(x => x.Sequencial).IsRequired();
            
            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            
            builder.Property(x => x.Vencimento).IsRequired();
            
            builder.Property(x => x.Emissao).IsRequired();
            
            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasColumnType("varchar(50)"); 
           
            builder.Property(x => x.Token)
                .HasColumnType("varchar(500)");
            
            builder.Property(x => x.CriadoEm)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
            // Relationships
            builder.HasOne(x => x.Conta)
                .WithOne(x => x.Boleto)
                .HasForeignKey<ContaBancaria>(x => x.BoletoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Beneficiario)
                .WithOne(x => x.Boleto)
                .HasForeignKey<Beneficiario>(x => x.BoletoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Pagador)
                .WithOne(x => x.Boleto)
                .HasForeignKey<Pagador>(x => x.BoletoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Boletos");
        }
    }
}
