namespace BoletoCloudApi.Data.Context
{
    using BoletoCloudApi.Business.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Contexto do Entity Framework para acesso ao banco de dados da aplicação.
    /// Gerencia os conjuntos de entidades e configurações de mapeamento, além de otimizar o rastreamento de alterações.
    /// </summary>
    public class MeuDbContext : DbContext
    {
        /// <summary>
        /// Inicializa uma nova instância do contexto <see cref="MeuDbContext"/>.
        /// Configura o rastreamento de consultas para não rastrear entidades e desabilita a detecção automática de alterações.
        /// </summary>
        /// <param name="options">Opções de configuração do contexto.</param>
        public MeuDbContext(DbContextOptions<MeuDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        /// <summary>
        /// Conjunto de entidades <see cref="Boleto"/>.
        /// </summary>
        public DbSet<Boleto> Boletos { get; set; }

        /// <summary>
        /// Conjunto de entidades <see cref="ContaBancaria"/>.
        /// </summary>
        public DbSet<ContaBancaria> ContasBancarias { get; set; }

        /// <summary>
        /// Conjunto de entidades <see cref="Beneficiario"/>.
        /// </summary>
        public DbSet<Beneficiario> Beneficiarios { get; set; }

        /// <summary>
        /// Conjunto de entidades <see cref="Pagador"/>.
        /// </summary>
        public DbSet<Pagador> Pagadores { get; set; }

        /// <summary>
        /// Configura o mapeamento das entidades e propriedades do modelo.
        /// Define o tipo das colunas string como varchar(100), aplica configurações do assembly
        /// e ajusta o comportamento de deleção para relacionamentos.
        /// </summary>
        /// <param name="modelBuilder">Construtor do modelo de entidades.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
