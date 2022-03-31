using System;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        Task<TodoItem> GetByIdAsync(Guid id, string user);
        Task Create(TodoItem todo);
        Task Upadate(TodoItem todo);
    }
}
