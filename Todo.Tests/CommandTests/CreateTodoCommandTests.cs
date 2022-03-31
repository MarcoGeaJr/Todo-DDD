using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands.TodoCommands;

namespace Todo.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.UtcNow);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("This is a valid Title", "UserValid", DateTime.UtcNow);

        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            // Act
            _invalidCommand.Validate();

            // Assert
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            // Act
            _validCommand.Validate();

            // Assert
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
