using HumanGuide.Core.Application.Interfaces.Repositories;

namespace HumanGuide.Core.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IHumanRepository HumanRepository { get; }
        ICityRepository CityRepository { get; }
        IPhoneRepository PhoneRepository { get; }
        IHuman2PhoneRepository Human2PhoneRepository { get; }
        IConnecteHumanRepository ConnecteHumanRepository { get; }
    }
}
