using BoletoCloudApi.Business.Interfaces;
using BoletoCloudApi.Business.Models;
using BoletoCloudApi.Data.Context;
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
    }
}
