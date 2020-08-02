using Microsoft.EntityFrameworkCore;

namespace efdemo1.Models {
    public class TodoContext : DbContext {
        public TodoContext (DbContextOptions<TodoContext> options) : base (options) { }
        public DbSet<Todo> Todos { get; set; }
    }
}