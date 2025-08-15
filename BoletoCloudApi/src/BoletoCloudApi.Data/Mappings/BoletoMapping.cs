namespace BoletoCloudApi.Data.Mappings
{
    using BoletoCloudApi.Business.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Configuração de mapeamento da entidade <see cref="Boleto"/> para o Entity Framework.
    /// Define propriedades, tipos de coluna, restrições e relacionamentos para persistência no banco de dados.
    /// </summary>
    public class BoletoMapping : IEntityTypeConfiguration<Boleto>
    {
        /// <summary>
        /// Configura o mapeamento da entidade <see cref="Boleto"/>,
        /// especificando chave primária, tipos de coluna, obrigatoriedade, valores padrão,
        /// relacionamentos e nome da tabela.
        /// </summary>
        /// <param name="builder">Construtor de configuração para a entidade.</param>
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
