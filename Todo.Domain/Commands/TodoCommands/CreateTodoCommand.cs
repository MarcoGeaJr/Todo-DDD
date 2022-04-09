using Flunt.Notifications;
using Flunt.Validations;
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
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 3, "Title", "Descreva melhor á tarefa!")
                    .HasMinLen(User, 4, "User", "Usuário inválido.")
                );
        }
    }
}
