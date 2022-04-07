using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        Task<TodoItem> GetByIdAsync(Guid id, string user);
        Task Create(TodoItem todo);
        Task Upadate(TodoItem todo);
        Task<IEnumerable<TodoItem>> GetAll(string user);
        Task<IEnumerable<TodoItem>> GetAllDone(string user);
        Task<IEnumerable<TodoItem>> GetAllUnDone(string user);
        Task<IEnumerable<TodoItem>> GetByPeriod(string user, DateTime time, bool done);
    }
}
