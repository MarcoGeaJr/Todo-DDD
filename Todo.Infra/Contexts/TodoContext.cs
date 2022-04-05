using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Infra.Mappings;

namespace Todo.Infra.Contexts
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoItemMapping());
        }
        public DbSet<TodoItem> Todos { get; set; }
    }
}
