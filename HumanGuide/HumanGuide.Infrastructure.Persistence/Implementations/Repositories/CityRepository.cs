using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Repositories
{
   public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(DataContext context) : base(context)
        {
        }
    }
}
