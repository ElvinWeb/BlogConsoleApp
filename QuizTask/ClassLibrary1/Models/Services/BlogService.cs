using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Exceptions;
using ClassLibrary.Models.DataBase;
using ClassLibrary.Models.MainClasses;

namespace ClassLibrary.Models.Services
{
    public static class BlogService
    {
        public static void AddBlog(Blog blog)
        {

            BlogDataBase.Blogs.Add(blog);
        }

        public static void RemoveBlog(int? id)
        {
            Blog blogToRemove = BlogDataBase.Blogs.Find(blog => blog.Id == id);
            if (blogToRemove != null)
            {
                BlogDataBase.Blogs.Remove(blogToRemove);
                Console.WriteLine("Verilmis Id gore Blog silindi!");
            }
            else
            {
                throw new BlogNotFoundException("Blog tapilmadi");
            }
        }
        public static Blog GetBlogById(int? id)
        {

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
