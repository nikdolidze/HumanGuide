using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Repositories
{
    public class HumanRepository : Repository<Human>, IHumanRepository
    {
        public HumanRepository(DataContext context) : base(context)
        {
        }


        private IQueryable<Human> Including =>
         this.context.Humans.Include(x => x.City)
            .Include(x => x.Human2Phones).ThenInclude(y => y.Phone)
            .Include(x => x.ConnecteHumans);

        public override async Task<Human> ReadAsync(int id)
        {
            return await this.Including.FirstOrDefaultAsync(x => x.Id == id);
        }


        //   public override async Task<IEnumerable<Human2Phone>> ReadAsync(Expression<Func<Human2Phone, bool>> predicate)
        //   {
        //       return await this.Including.Where(predicate).ToListAsync();
        //   }
    }

}
