using BoletoCloudApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoCloudApi.Data.Mappings
{
    public class ContaBancariaMapping : IEntityTypeConfiguration<ContaBancaria>
    {
        public void Configure(EntityTypeBuilder<ContaBancaria> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Numero)
                .IsRequired()
                .HasColumnType("varchar(20)");
            builder.Property(x => x.Sequencial).IsRequired();
            builder.Property(x => x.Banco)
                .IsRequired()
                .HasColumnType("varchar(50)");
            builder.Property(x => x.Agencia)
                .IsRequired()
                .HasColumnType("varchar(20)");
            builder.Property(x => x.Carteira)
                .IsRequired()
                .HasColumnType("varchar(20)");
            
            builder.ToTable("ContaBancarias");
        }
    }
}
