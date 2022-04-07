using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;
using Todo.Infra.Contexts;

namespace Todo.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task Create(TodoItem todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetAll(string user)
        {
            return _context.Todos
                            .AsNoTracking()
                            .Where(TodoQueries.GetAll(user))
                            .OrderBy(x => x.Date);
        }

        public async Task<IEnumerable<TodoItem>> GetAllDone(string user)
        {
            return _context.Todos
                            .AsNoTracking()
                            .Where(TodoQueries.GetAllDone(user))
                            .OrderBy(x => x.Date);
        }

        public async Task<IEnumerable<TodoItem>> GetAllUnDone(string user)
        {
            return _context.Todos
                            .AsNoTracking()
                            .Where(TodoQueries.GetAllUnDone(user))
                            .OrderBy(x => x.Date);
        }

        public async Task<TodoItem> GetByIdAsync(Guid id, string user)
        {
            return await _context.Todos.FirstOrDefaultAsync(x => x.Id == id && x.User == user);
        }

        public async Task<IEnumerable<TodoItem>> GetByPeriod(string user, DateTime time, bool done)
        {
            return _context.Todos
                           .AsNoTracking()
                           .Where(TodoQueries.GetByPeriod(user, time, done))
                           .OrderBy(x => x.Date);
        }

        public async Task Upadate(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
