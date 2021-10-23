using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Repositories
{
    class ConnecteHumanRepository : Repository<ConnecteHuman>, IConnecteHumanRepository
    {
        public ConnecteHumanRepository(DataContext context) : base(context)
        {
        }
     
    }
}
