using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Tests.QueryTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        // Arrange
        private List<TodoItem> _items = new();

        public TodoQueriesTests()
        {
            _items.Add(new TodoItem("Tarefa 1", DateTime.UtcNow, "user1"));
            _items.Add(new TodoItem("Tarefa 2", DateTime.UtcNow.AddDays(1), "user2"));

            var tarefa = new TodoItem("Tarefa 3", DateTime.UtcNow.AddDays(2), "user2");
            tarefa.MarkAsDone();
            _items.Add(tarefa);

            tarefa = new TodoItem("Tarefa 4", DateTime.UtcNow.AddDays(1), "user1");
            tarefa.MarkAsDone();
            _items.Add(tarefa);

            _items.Add(new TodoItem("Tarefa 5", DateTime.UtcNow, "user3"));
            _items.Add(new TodoItem("Tarefa 6", DateTime.UtcNow.AddDays(1), "user1"));
        }

        [TestMethod]
        public void Deve_retornar_apenas_tarefas_do_usuario_informado()
        {
            // Act
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("user1"));

            // Assert
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_apenas_tarefas_concluidas_do_usuario_informado()
        {
            // Act
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("user1"));

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_apenas_tarefas_nao_concluidas_do_usuario_informado()
        {
            // Act
            var result = _items.AsQueryable().Where(TodoQueries.GetAllUnDone("user1"));

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_apenas_tarefas_concluidas_do_periodo_do_usuario_informado()
        {
            // Act
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("user1", DateTime.Now, true));

            // Assert
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_apenas_tarefas_nao_concluidas_do_periodo_do_usuario_informado()
        {
            // Act
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("user1", DateTime.UtcNow.AddDays(1), false));

            // Assert
            Assert.AreEqual(1, result.Count());
        }
    }
}
