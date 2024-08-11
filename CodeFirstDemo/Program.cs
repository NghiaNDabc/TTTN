using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    public class Program
    {
        public class Post
        {
            public int Id { get; set; }
            public DateTime DatePublished { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
        }
        class BlogDbContext : DbContext
        {
            public DbSet<Post> Posts { get; set; }
        }
        static void Main()
        {
        }
    }
}
