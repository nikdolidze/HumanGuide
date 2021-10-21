using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Infrastructure.Persistence.Implementations.Repositories;

namespace HumanGuide.Infrastructure.Persistence.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private IHumanRepository humanRepository;

        private readonly DataContext context;
        public UnitOfWork(DataContext context) => this.context = context;

        public IHumanRepository HumanRepository => humanRepository ??= new HumanRepository(context);
    }
}
