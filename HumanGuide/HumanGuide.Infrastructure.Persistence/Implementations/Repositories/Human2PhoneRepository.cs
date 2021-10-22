using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Entities;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Repositories
{
    class Human2PhoneRepository : Repository<Human2Phone>, IHuman2PhoneRepository
    {
        public Human2PhoneRepository(DataContext context) : base(context)
        {
        }
    }
}
