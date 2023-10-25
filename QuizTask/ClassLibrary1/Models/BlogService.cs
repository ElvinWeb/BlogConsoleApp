using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public static class BlogService
    {
        public static void AddBlog(Blog blog)
        {
            if (blog == null)
            {
                Console.WriteLine("Blog obyekti null ola bilmez!!");
            }
            BlogDataBase.Blogs.Add(blog);
        }

        public static void RemoveBlog(int? id)
        {
            for (int i = 0; i < BlogDataBase.Blogs.Count; i++)
            {
                if (BlogDataBase.Blogs[i].Id == id && id != null)
                {
                    BlogDataBase.Blogs.RemoveAt(i);
                }
                else
                {
                    Console.WriteLine("Id deyer null ola bilmez!!!");
                }
            }
        }
        public static Blog GetBlogById(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Id deyer null ola bilmez!!!");
            }

            return BlogDataBase.Blogs.Find(blogId => id == blogId.Id);
        }
        public static List<Blog> GetAllBlogs()
        {
            return BlogDataBase.Blogs;
        }

        public static List<Blog> GetBlogsByValue(string value)
        {
            return BlogDataBase.Blogs.FindAll(blog =>
            blog.Title.Trim().ToLower().Contains(value.Trim().ToLower()) ||
            blog.Description.Trim().ToLower().Contains(value.Trim().ToLower()));
        }
    }
}
