using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Entities;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Repositories
{
    class ConnectedHumanRepository : Repository<ConnectedHuman>, IConnectedHumanRepository
    {
        public ConnectedHumanRepository(DataContext context) : base(context)
        {
        }

    }
}
