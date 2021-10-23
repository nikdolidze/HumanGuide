using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Repositories
{
    class ConnecteHumanRepository : Repository<ConnecteHuman>, IConnecteHumanRepository
    {
        public ConnecteHumanRepository(DataContext context) : base(context)
        {
        }
        private IQueryable<ConnecteHuman> Including =>
       this.context.ConnecteHuman.Include(x => x.ConnecteHumans);




        public override async Task<IEnumerable<ConnecteHuman>> ReadAsync(Expression<Func<ConnecteHuman, bool>> predicate)
        {
            return await this.Including.Where(predicate).ToListAsync();
        }
    }
}
