using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class EventDBContext:DbContext
    {
        public EventDBContext() : base("name=CapstoneDBConnectionString")
        {
            Database.SetInitializer<EventDBContext>(new EventDBInitializer()); 
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Asset> Assets { get; set; }

    }
}