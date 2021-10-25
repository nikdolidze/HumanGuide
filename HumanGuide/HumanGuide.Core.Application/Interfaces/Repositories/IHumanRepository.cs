using HumanGuide.Core.Application.Common;
using HumanGuide.Core.Domain.Entities;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Interfaces.Repositories
{
    public interface IHumanRepository : IRepository<Human>
    {
        Task<Pagination<Human>> FilterAsync(int pageIndex, int pageSize, string personalNo = null, string firstName = null, string lastName = null);

    }
}
