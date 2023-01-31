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
    class Human2PhoneRepository : Repository<Human2Phone>, IHuman2PhoneRepository
    {
        public Human2PhoneRepository(DataContext context) : base(context) { }

        private IQueryable<Human2Phone> Including =>
         this.context.Human2Phone.Include(x => x.Phone);

        public override async Task<IEnumerable<Human2Phone>> ReadAsync(Expression<Func<Human2Phone, bool>> predicate)
            => await this.Including.Where(predicate).ToListAsync();
    }
}
