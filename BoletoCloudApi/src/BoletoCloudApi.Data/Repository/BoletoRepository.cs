using BoletoCloudApi.Business.Interfaces;
using BoletoCloudApi.Business.Models;
using BoletoCloudApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoCloudApi.Data.Repository
{
    public class BoletoRepository : Repository<Boleto>, IBoletoRepository
    {
        public BoletoRepository(MeuDbContext context) : base(context) { }

        public async Task<Boleto> ObterBoletoPorIdAsync(Guid BoletoId)
        {
            return await Db.Boletos
                .AsNoTracking()
                .Include(b => b.Conta)
                .Include(b => b.Beneficiario)
                .Include(b => b.Pagador)
                .FirstOrDefaultAsync(b => b.Id == BoletoId);
        }
    }
}
