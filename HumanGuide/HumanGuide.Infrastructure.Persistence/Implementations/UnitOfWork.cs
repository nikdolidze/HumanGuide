using HumanGuide.Core.Application.Interfaces;
using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Infrastructure.Persistence.Implementations.Repositories;

namespace HumanGuide.Infrastructure.Persistence.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private IHumanRepository humanRepository;
        private ICityRepository cityRepository;
        private IPhoneRepository phoneRepository;
        private IHuman2PhoneRepository human2PhoneRepository;
        private IConnectedHumanRepository connectedHumanRepository;

        private readonly DataContext context;
        public UnitOfWork(DataContext context) => this.context = context;


        public IHumanRepository HumanRepository => humanRepository ??= new HumanRepository(context);
        public ICityRepository CityRepository => cityRepository ??= new CityRepository(context);
        public IPhoneRepository PhoneRepository => phoneRepository ??= new PhoneRepository(context);

        public IHuman2PhoneRepository Human2PhoneRepository => human2PhoneRepository ??= new Human2PhoneRepository(context);

        public IConnectedHumanRepository ConnectedHumanRepository => connectedHumanRepository ??= new ConnectedHumanRepository(context);
    }
}
