using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Entities;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Repositories
{
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        public PhoneRepository(DataContext context) : base(context)
        {
        }
    }
}


