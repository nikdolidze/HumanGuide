using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Repositories
{
    class Human2PhoneRepository : Repository<Human2Phone>, IHuman2PhoneRepository
    {
        public Human2PhoneRepository(DataContext context) : base(context)
        {
        }
    }
}
