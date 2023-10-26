using ClassLibrary.Enums;
using ClassLibrary.Exceptions;
using ClassLibrary.Models.MainClasses;
using ClassLibrary.Models.Services;
using System.Xml.Linq;

namespace QuizTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppStart();
        }
        static void AppStart()
        {
            BlogRegisterSection();
        }
        static void BlogMenuSection()
        {
            string blogChoice;
            do
            {

                Console.WriteLine("<==== Blog Menu =====> ");
                Console.WriteLine("Emeliyyat sec: ");
                Console.WriteLine("\n1.Blog elave et" +
                    "\n2.Blog sil" +
                    "\n3.Blog detail " +
                    "\n4.Butun bloglara bax" +
                    "\n5.Bloglari filterle" +
                    "\n0.Proqramı bitir");

                blogChoice = Console.ReadLine();
                switch (blogChoice)
                {
                    case "1":
                        Console.Write("Basligi elave edin: ");
                        string title = Console.ReadLine();

                        Console.Write("Description elave edin: ");
                        string desc = Console.ReadLine();

                        Console.WriteLine("Blog Type secin");
                        Console.WriteLine("1 - Programming, 2 - Educational, 3 - Thriller");

                        BlogType blogType = BlogType.Programming;
                        string type;
                        type = Console.ReadLine();

                        switch (type)
                        {
                            case "1":
                                blogType = BlogType.Programming;
                                break;
                            case "2":
                                blogType = BlogType.Educational;
                                break;
                            case "3":
                                blogType = BlogType.Thriller;
                                break;
                            default:
                                Console.WriteLine("Bele blog type yoxdur");
                                break;
                        }
                        BlogService.AddBlog(new Blog(title.Trim(), desc.Trim(), blogType));
                        Console.WriteLine("Blog Ugurla elave edildi");
                        break;
                    case "2":
                        string removeStr;
                        int numRemoveId;

                        do
                        {
                            Console.Write("Id daxil edin: ");
                            removeStr = Console.ReadLine();

                        } while (!int.TryParse(removeStr, out numRemoveId));
                        try
                        {

                        BlogService.RemoveBlog(numRemoveId);
                        }
                        catch(BlogNotFoundException ex)
                        {
                           Console.WriteLine($"{ex.Message}");
                        }
                       
                        break;
                    case "3":
                        string getStr;
                        int getId;

                        do
                        {
                            Console.Write("Id daxil edin: ");
                            getStr = Console.ReadLine();

                        } while (!int.TryParse(getStr, out getId));

                        BlogService.GetBlogById(getId).ShowInfo();

                        break;
                    case "4":
                        List<Blog> allBlogs = BlogService.GetAllBlogs();
                        IterateBlogsArr(allBlogs);
                        break;
                    case "5":
                        Console.Write("Axtaris ucun deyer daxil edin: ");
                        string searchVal = Console.ReadLine();

                        List<Blog> getBlogsByValue = BlogService.GetBlogsByValue(searchVal.Trim());
                        IterateBlogsArr(getBlogsByValue);
                        break;
                    default:
                        break;
                }

            } while (blogChoice != "0");

        }
        static void BlogRegisterSection()
        {
            string choice;
            do
            {
                Console.WriteLine("<===== Menu =====> ");
                Console.WriteLine("1.Register");
                Console.WriteLine("2.Login");

                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Name elave et: ");
                        string inputName = Console.ReadLine();

                        Console.Write("Surname elave et: ");
                        string inputSurname = Console.ReadLine();

                        Console.Write("Password elave et: ");
                        string inputPassword = Console.ReadLine();
                        try
                        {
                            UserService.Register(inputName.Trim(), inputSurname.Trim(), inputPassword.Trim());
                            Console.WriteLine("Qeydiyyat Ugurla tamamlandi)");

                        }
                        catch (InvalidNameException ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        catch (InvalidSurNameException ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        catch (InvalidPasswordException ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }

                        break;
                    case "2":
                        bool loginCheck = false;
                        do
                        {
                            Console.WriteLine("username elave et: ");
                            string inputUsername = Console.ReadLine();

                            Console.WriteLine("password elave et: ");
                            string inputPass = Console.ReadLine();
                            loginCheck = UserService.Login(inputUsername.Trim(), inputPass.Trim());

                            if (loginCheck)
                            {
                                BlogMenuSection();
                            }
                            else
                            {
                                Console.WriteLine("Username ve passworda sehvlik var!!!");
                            }

                        } while (!loginCheck);
                        break;
                    default:
                        break;
                }
            } while (choice == "1");

        }
        static void IterateBlogsArr(List<Blog> blogsArr)
        {
            foreach (var blog in blogsArr)
            {
                blog.ShowInfo();
            }
        }
    }
}