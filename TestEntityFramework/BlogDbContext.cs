using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntityFramework
{
    internal class BlogDbContext :DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}
