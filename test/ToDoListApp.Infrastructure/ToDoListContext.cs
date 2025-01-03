using Microsoft.EntityFrameworkCore;
using ToDoListApp.Domain;

namespace ToDoListApp.Infrastructure
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }


        public DbSet<ToDoList> ToDoLists { get; set; }

    }
}
