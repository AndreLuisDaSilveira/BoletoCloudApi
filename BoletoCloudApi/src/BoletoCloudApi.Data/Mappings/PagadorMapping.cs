namespace BoletoCloudApi.Data.Mappings
{
    using BoletoCloudApi.Business.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Configuração de mapeamento da entidade <see cref="Pagador"/> para o Entity Framework.
    /// Define propriedades, tipos de coluna e restrições para persistência no banco de dados.
    /// </summary>
    public class PagadorMapping : IEntityTypeConfiguration<Pagador>
    {
        /// <summary>
        /// Configura o mapeamento da entidade <see cref="Pagador"/>,
        /// especificando chave primária, tipos de coluna, obrigatoriedade e nome da tabela.
        /// </summary>
        /// <param name="builder">Construtor de configuração para a entidade.</param>
        public void Configure(EntityTypeBuilder<Pagador> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");
            builder.Property(x => x.CpfCnpj)
                .IsRequired()
                .HasColumnType("varchar(14)");
            builder.Property(x => x.Cep)
                .IsRequired()
                .HasColumnType("varchar(10)");
            builder.Property(x => x.Uf)
                .IsRequired()
                .HasColumnType("varchar(2)");
            builder.Property(x => x.Localidade)
                .IsRequired()
                .HasColumnType("varchar(30)");
            builder.Property(x => x.Bairro)
                .IsRequired()
                .HasColumnType("varchar(30)");
            builder.Property(x => x.Logradouro)
                .HasColumnType("varchar(30)")
                .IsRequired();
            builder.Property(x => x.Numero)
                .HasColumnType("varchar(10)")
                .IsRequired();
            //builder.Property(x => x.BoletoId)
            //    .IsRequired();
            builder.ToTable("Pagadores");
        }
    }
}
