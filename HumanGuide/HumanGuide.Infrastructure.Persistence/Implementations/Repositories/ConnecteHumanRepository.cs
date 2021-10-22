using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Entities;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Repositories
{
    class ConnecteHumanRepository : Repository<ConnecteHuman>, IConnecteHumanRepository
    {
        public ConnecteHumanRepository(DataContext context) : base(context)
        {
        }
    }
}
