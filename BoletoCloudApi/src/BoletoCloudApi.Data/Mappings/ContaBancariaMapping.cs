namespace BoletoCloudApi.Data.Mappings
{
    using BoletoCloudApi.Business.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Configuração de mapeamento da entidade <see cref="ContaBancaria"/> para o Entity Framework.
    /// Define propriedades, tipos de coluna e restrições para persistência no banco de dados.
    /// </summary>
    public class ContaBancariaMapping : IEntityTypeConfiguration<ContaBancaria>
    {
        /// <summary>
        /// Configura o mapeamento da entidade <see cref="ContaBancaria"/>,
        /// especificando chave primária, tipos de coluna, obrigatoriedade e nome da tabela.
        /// </summary>
        /// <param name="builder">Construtor de configuração para a entidade.</param>
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
