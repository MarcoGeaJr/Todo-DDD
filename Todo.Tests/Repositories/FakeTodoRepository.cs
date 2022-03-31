using System;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public Task Create(TodoItem todo)
        {
            return Task.CompletedTask;
        }

        public Task<TodoItem> GetByIdAsync(Guid id, string user)
        {
            return Task.FromResult<TodoItem>(new TodoItem("Title", DateTime.UtcNow, user));
        }

        public Task Upadate(TodoItem todo)
        {
            return Task.CompletedTask;
        }
    }
}
