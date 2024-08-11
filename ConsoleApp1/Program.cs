using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
       
        public class Course
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public CourseLevel Level { get; set; }
            public string Descriptsion { get; set; }
            public float FullPrice { get;set; }
            public  Author Author { get; set; }
            public IList<Tag> Tags { get; set; }
                
        }

        public class Author
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public IList<Course> Courses { get; set; }
        }

        public class Tag
        {
            public int id { get; set; }
            public string Name { get; set; }
            public IList<Course> Courses { get; set; }
        }
        public enum CourseLevel
        {
            Beginner = 1,
            Intermdiate = 2,
            Advanced = 3
        }
        static void Main(string[] args)
        {

            using (var context = new PlutoContext())
            {
                // Tạo tác giả
                var author = new Author { Name = "John Doe" };

                // Tạo tag
                var tag1 = new Tag { Name = "C#" };
                var tag2 = new Tag { Name = "Entity Framework" };

                // Tạo khóa học
                var course = new Course
                {
                    Title = "Entity Framework in Depth",
                    Level = CourseLevel.Advanced,
                    Descriptsion = "A comprehensive course on Entity Framework",
                    FullPrice = 49.99f,
                    Author = author,
                    Tags = new List<Tag> { tag1, tag2 }
                };

                // Thêm dữ liệu vào context
                context.Authors.Add(author);
                context.Tags.Add(tag1);
                context.Tags.Add(tag2);
                context.Courses.Add(course);

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SaveChanges();
            }

            Console.WriteLine("Dữ liệu đã được chèn thành công.");
            Console.ReadKey();
        }
    }
}
