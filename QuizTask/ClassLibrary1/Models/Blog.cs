using ClassLibrary1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public class Blog
    {
        private static int _count { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BlogType BlogType { get; set; }



        static Blog()
        {
            _count = 0;
        }

        public Blog(string title, string desc, BlogType blogType)
        {
            _count++;
            this.Id = _count;
            this.Title = title;
            this.Description = desc;
            this.BlogType = blogType;

        }
        public void ShowInfo()
        {
            Console.WriteLine($"Basliq:{Title} -> Tesviri:{Description} -> Movzusu:{BlogType}");
        }
    }
}
