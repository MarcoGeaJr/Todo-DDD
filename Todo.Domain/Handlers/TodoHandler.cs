using System.Threading.Tasks;
using Todo.Domain.Commands.TodoCommands;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
using Todo.Shared.Commands;
using Todo.Shared.Contracts;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
                IHandler<CreateTodoCommand>,
                IHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _todoRepostiory;

        public TodoHandler(ITodoRepository todoRepostiory)
        {
            _todoRepostiory = todoRepostiory;
        }

        public async Task<ICommandResult> Handle(CreateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Modelo inválido.", command.Notifications);

            // Criar
            var todoItem = new TodoItem(command.Title, command.Date, command.User);

            // Inserir
            await _todoRepostiory.Create(todoItem);

            // Devolver
            return new GenericCommandResult(true, "Tarefa cadastrada com sucesso!", todoItem);
        }

        public async Task<ICommandResult> Handle(UpdateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Modelo inválido.", command.Notifications);

            // Recupera a todo do banco (Rehidratação)
            var todoItem = await _todoRepostiory.GetByIdAsync(command.Id, command.User);

            // Altera o titulo
            todoItem.UpdateTitle(command.Title);

            // Alterar no banco
            await _todoRepostiory.Upadate(todoItem);

            // Devolver
            return new GenericCommandResult(true, "Tarefa alterada com sucesso!", todoItem);
        }
    }
}
