using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public Task Create(TodoItem todo)
        {
            throw new NotImplementedException();
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

        public Task<TodoItem> GetById(Guid id, string user)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetByIdAsync(Guid id, string user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetByPeriod(string user)
        {
            throw new NotImplementedException();
        }

        public Task Upadate(TodoItem todo)
        {
            throw new NotImplementedException();
        }
    }
}
