using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands.TodoCommands;
using Todo.Domain.Handlers;
using Todo.Shared.Commands;
using Todo.Tests.Repositories;

namespace Todo.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        // Arrange
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.UtcNow);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("This is a valid Title", "UserValid", DateTime.UtcNow);
        private readonly TodoHandler _todoHandler = new TodoHandler(new FakeTodoRepository());
        private GenericCommandResult _commandResult = new GenericCommandResult();

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_execucao()
        {
            // Act
            _commandResult = (GenericCommandResult)_todoHandler.Handle(_invalidCommand).Result;

            // Assert
            Assert.AreEqual(_commandResult.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_a_tarefa()
        {
            // Act
            _commandResult = (GenericCommandResult)_todoHandler.Handle(_validCommand).Result;

            // Assert
            Assert.AreEqual(_commandResult.Success, true);
        }
    }
}
