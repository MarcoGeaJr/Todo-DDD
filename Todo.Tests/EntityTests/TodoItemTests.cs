using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Entities;

namespace Todo.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _todoItem = new TodoItem("Title", DateTime.UtcNow, "User");

        [TestMethod]
        public void Dado_um_novo_todo_done_deve_ser_false()
        {
            // Assert
            Assert.AreEqual(_todoItem.Done, false);
        }
    }
}
