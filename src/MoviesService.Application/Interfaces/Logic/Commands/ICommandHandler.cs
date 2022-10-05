using MoviesService.Application.Commands.CreateMovie;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Interfaces.Logic.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(CreateMovie model);
    }
}
