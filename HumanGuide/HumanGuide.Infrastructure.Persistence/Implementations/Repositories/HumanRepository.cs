﻿using HumanGuide.Core.Application.Common;
using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HumanGuide.Infrastructure.Persistence.Implementations.Repositories
{
    public class HumanRepository : Repository<Human>, IHumanRepository
    {
        public HumanRepository(DataContext context) : base(context)
        {
        }

        private IQueryable<Human> Including =>
         this.context.Humans.Include(x => x.City)
            .Include(x => x.Human2Phones).ThenInclude(y => y.Phone)
            .Include(x => x.BaseConnectedHumans)
                .ThenInclude(x => x.BaseConnectedHuman)
                    .ThenInclude(x => x.Human2Phones).ThenInclude(x => x.Phone);

        public async Task<Pagination<Human>> FilterAsync(int pageIndex, int pageSize, string personalNo = null, string firstName = null, string lastName = null)
        {
            var humans = this.Including.Where(x =>
                          (personalNo == null || x.PersonalNo.Contains(personalNo)) &&
                          (firstName == null || x.FirstName.Contains(firstName)) &&
                          (lastName == null || x.LastName.Contains(lastName)));

            return await Pagination<Human>.CreateAsync(humans, pageIndex, pageSize);
        }

        public override async Task<Human> ReadAsync(int id)
        {
            return await this.Including.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
