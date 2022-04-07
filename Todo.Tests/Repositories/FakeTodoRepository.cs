using System;
using System.Collections.Generic;
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

        public Task<IEnumerable<TodoItem>> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetAllUnDone(string user)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetByIdAsync(Guid id, string user)
        {
            return Task.FromResult<TodoItem>(new TodoItem("Title", DateTime.UtcNow, user));
        }

        public Task<IEnumerable<TodoItem>> GetByPeriod(string user, DateTime time, bool done)
        {
            throw new NotImplementedException();
        }

        public Task Upadate(TodoItem todo)
        {
            return Task.CompletedTask;
        }
    }
}
