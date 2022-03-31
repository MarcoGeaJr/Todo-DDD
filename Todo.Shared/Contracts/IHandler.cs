using System.Threading.Tasks;

namespace Todo.Shared.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
