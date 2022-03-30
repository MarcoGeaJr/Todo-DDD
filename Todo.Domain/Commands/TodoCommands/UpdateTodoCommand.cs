using Flunt.Notifications;
using System;
using Todo.Shared.Contracts;

namespace Todo.Domain.Commands.TodoCommands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand() { }

        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            if (Title.Length < 4)
            {
                AddNotification("Titulo", "O titulo não pode ser menor que 4");
            }
        }
    }
}
