namespace BoletoCloudApi.Business.Models
{
    /// <summary>
    /// Classe base abstrata para entidades do domínio, fornecendo um identificador único.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Entity"/> atribuindo um identificador único.
        /// </summary>
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Identificador único da entidade.
        /// </summary>
        public Guid Id { get; set; }
    }
}
