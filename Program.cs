using System;
using System.Linq;
using efdemo1.Models;
using Microsoft.EntityFrameworkCore;

namespace efdemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Todo0802;Integrated Security=true;");

            using(var db = new TodoContext(optionsBuilder.Options))
            {
                var todo = new Todo()
                {
                Item = "Item 1"
                };
                db.Todos.Add(todo);
                db.SaveChanges();

                todo.Item = "Item " + todo.Id;
                db.SaveChanges();

                var first = db.Todos.Find(1);
                if (first != null)
                {
                    db.Todos.Remove(first);
                    db.SaveChanges();
                }
            }

            using(var db = new TodoContext(optionsBuilder.Options))
            {
                var data = db.Todos.ToList();

                foreach (var item in data)
                {
                    Console.WriteLine(item.Item);
                }
            }
        }
    }
}