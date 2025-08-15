namespace BoletoCloudApi.Data.Repository
{
    using BoletoCloudApi.Business.Interfaces;
    using BoletoCloudApi.Business.Models;
    using BoletoCloudApi.Data.Context;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repositório especializado para operações de persistência e consulta de boletos.
    /// Implementa métodos específicos para obtenção de boletos com suas entidades relacionadas.
    /// </summary>
    public class BoletoRepository : Repository<Boleto>, IBoletoRepository
    {
        /// <summary>
        /// Inicializa uma nova instância do <see cref="BoletoRepository"/> com o contexto de banco de dados informado.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public BoletoRepository(MeuDbContext context) : base(context) { }

        /// <summary>
        /// Obtém um boleto pelo identificador informado, incluindo os dados de conta bancária, beneficiário e pagador relacionados.
        /// </summary>
        /// <param name="boletoId">Identificador único do boleto.</param>
        /// <returns>O <see cref="Boleto"/> correspondente ao identificador ou <c>null</c> se não encontrado.</returns>
        public async Task<Boleto> ObterBoletoPorIdAsync(Guid boletoId)
        {
            return await Db.Boletos
                .AsNoTracking()
                .Include(b => b.Conta)
                .Include(b => b.Beneficiario)
                .Include(b => b.Pagador)
                .FirstOrDefaultAsync(b => b.Id == boletoId);
        }
    }
}
