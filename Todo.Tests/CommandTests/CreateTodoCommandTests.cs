using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands.TodoCommands;

namespace Todo.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            // Arrange
            var command = new CreateTodoCommand("", "", DateTime.UtcNow);

            // Act
            command.Validate();

            // Assert
            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            // Arrange
            var command = new CreateTodoCommand("This is a valid Title", "UserValid", DateTime.UtcNow);

            // Act
            command.Validate();

            // Assert
            Assert.AreEqual(command.Valid, true);
        }
    }
}
