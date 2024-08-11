using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntityFramework
{
    internal class Post
    {
        public int Id { get; set; } 
        public DateTime DatePublished { get; set; }
        public string Title { get; set; } 
        public string Body { get; set; }
    }
}
