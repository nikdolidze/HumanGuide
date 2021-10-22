using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Repositories
{
    class ConnecteHumanRepository : Repository<ConnecteHuman>, IConnectedConnecteHumanRepository
    {
        public ConnecteHumanRepository(DataContext context) : base(context)
        {
        }
    }
}
