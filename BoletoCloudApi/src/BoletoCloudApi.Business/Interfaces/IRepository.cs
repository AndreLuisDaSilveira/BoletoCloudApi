namespace BoletoCloudApi.Business.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using BoletoCloudApi.Business.Models;

    /// <summary>
    /// Interface genérica para repositórios de entidades, definindo operações básicas de acesso a dados.
    /// Permite adicionar, consultar, buscar e persistir entidades, além de liberar recursos.
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade gerenciada pelo repositório.</typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        /// <summary>
        /// Adiciona uma nova entidade ao repositório.
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada.</param>
        Task Adicionar(TEntity entity);

        /// <summary>
        /// Obtém uma entidade pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador da entidade.</param>
        /// <returns>Entidade encontrada ou <c>null</c> se não existir.</returns>
        Task<TEntity> ObterPorId(Guid id);

        /// <summary>
        /// Obtém todas as entidades do tipo <typeparamref name="TEntity"/>.
        /// </summary>
        /// <returns>Lista de entidades.</returns>
        Task<List<TEntity>> ObterTodos();

        /// <summary>
        /// Busca entidades que atendam ao predicado informado.
        /// </summary>
        /// <param name="predicate">Expressão de filtro para busca.</param>
        /// <returns>Lista de entidades que satisfazem o predicado.</returns>
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Persiste as alterações realizadas no contexto do repositório.
        /// </summary>
        /// <returns>Número de registros afetados.</returns>
        Task<int> SaveChanges();
    }
}
