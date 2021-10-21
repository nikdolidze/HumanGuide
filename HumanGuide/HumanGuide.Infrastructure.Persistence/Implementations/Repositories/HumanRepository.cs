using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Entities;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Repositories
{
    public class HumanRepository : Repository<Human>, IHumanRepository
    {
        public HumanRepository(DataContext context) : base(context)
        {
        }
    }
}
