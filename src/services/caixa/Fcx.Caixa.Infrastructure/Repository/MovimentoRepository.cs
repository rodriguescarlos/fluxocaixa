using Dapper;
using Fcx.Caixa.Application.Ports.Repository;
using Fcx.Caixa.Domain;
using Fcx.Library.Application.Port;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Fcx.Caixa.Infrastructure.Repository
{
    public class MovimentoRepository : IMovimentoRepository
    {
        public readonly MovimentoContext context;
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public MovimentoRepository(MovimentoContext context)
        {
            this.context = context;
        }

        public void Adicionar(Movimento movimento)
        {
            context.Movimentos.Add(movimento);
        }

        public async Task<IEnumerable<Movimento>> ObterTodos()
        {
            return await context.Movimentos.ToListAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
