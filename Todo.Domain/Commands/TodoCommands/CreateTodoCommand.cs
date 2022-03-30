using Flunt.Notifications;
using System;
using Todo.Shared.Contracts;

namespace Todo.Domain.Commands.TodoCommands
{
    public sealed class CreateTodoCommand : Notifiable, ICommand
    {
        public CreateTodoCommand() { }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }

        public void Validate()
        {
            if (Title.Length < 4)
            {
                AddNotification("Titulo", "O titulo não pode ser menor que 4");
            }
        }
    }
}
