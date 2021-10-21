using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Entities;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(DataContext context) : base(context)
        {
        }
    }
}
