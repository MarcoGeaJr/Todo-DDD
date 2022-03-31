using Flunt.Notifications;
using Flunt.Validations;
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
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 3, "Title", "Descreva melhor á tarefa!")
                    .HasMinLen(User, 6, "User", "Usuário inválido.")
                );
        }
    }
}
