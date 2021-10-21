namespace HumanGuide.Core.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IHumanRepository HumanRepository { get; }

    }
}
