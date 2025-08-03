namespace BoletoCloudApi.Data.Repository
{
    using System.Linq.Expressions;
    using BoletoCloudApi.Business.Interfaces;
    using BoletoCloudApi.Business.Models;
    using BoletoCloudApi.Data.Context;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Classe base abstrata para repositórios de entidades, fornecendo operações comuns de acesso a dados
    /// como consulta, inclusão e persistência, utilizando Entity Framework.
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade gerenciada pelo repositório.</typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        /// <summary>
        /// Contexto do banco de dados utilizado pelo repositório.
        /// </summary>
        protected readonly MeuDbContext Db;

        /// <summary>
        /// Conjunto de entidades do tipo <typeparamref name="TEntity"/>.
        /// </summary>
        protected readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// Inicializa uma nova instância do repositório com o contexto informado.
        /// </summary>
        /// <param name="db">Instância do contexto de banco de dados.</param>
        protected Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        /// <summary>
        /// Obtém uma entidade pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador da entidade.</param>
        /// <returns>Entidade encontrada ou <c>null</c> se não existir.</returns>
        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        /// <summary>
        /// Obtém todas as entidades do tipo <typeparamref name="TEntity"/>.
        /// </summary>
        /// <returns>Lista de entidades.</returns>
        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        /// <summary>
        /// Busca entidades que atendam ao predicado informado.
        /// </summary>
        /// <param name="predicate">Expressão de filtro para busca.</param>
        /// <returns>Lista de entidades que satisfazem o predicado.</returns>
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Adiciona uma nova entidade ao conjunto e persiste no banco de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada.</param>
        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        // /// <summary>
        // /// Atualiza uma entidade existente no banco de dados.
        // /// </summary>
        // /// <param name="entity">Entidade a ser atualizada.</param>
        // public virtual async Task Atualizar(TEntity entity)
        // {
        //     DbSet.Update(entity);
        //     await SaveChanges();
        // }

        // /// <summary>
        // /// Remove uma entidade pelo seu identificador.
        // /// </summary>
        // /// <param name="id">Identificador da entidade a ser removida.</param>
        // public virtual async Task Remover(Guid id)
        // {
        //     DbSet.Remove(new TEntity { Id = id });
        //     await SaveChanges();
        // }

        /// <summary>
        /// Persiste as alterações realizadas no contexto do banco de dados.
        /// </summary>
        /// <returns>Número de registros afetados.</returns>
        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        /// <summary>
        /// Libera os recursos utilizados pelo contexto do banco de dados.
        /// </summary>
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
