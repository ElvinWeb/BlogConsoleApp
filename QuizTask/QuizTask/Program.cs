using ClassLibrary1.Enums;
using ClassLibrary1.Models;
using System.Xml.Linq;

namespace QuizTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice;
            bool loginCheck = false;
            do
            {
                Console.WriteLine("1.Register");
                Console.WriteLine("2.Login");

                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("name elave et: ");
                        string inputName = Console.ReadLine();

                        Console.Write("surname elave et: ");
                        string inputSurname = Console.ReadLine();

                        Console.Write("password elave et: ");
                        string inputPassword = Console.ReadLine();

                        UserService.Register(inputName.Trim(), inputSurname.Trim(), inputPassword.Trim());
                        break;
                    case "2":

                        do
                        {
                            Console.WriteLine("username elave et: ");
                            string inputUsername = Console.ReadLine();

                            Console.WriteLine("password elave et: ");
                            string inputPass = Console.ReadLine();
                            loginCheck = UserService.Login(inputUsername.Trim(), inputPass.Trim());

                        } while (!loginCheck);
                        break;
                }


            } while (choice == "1");

            if (loginCheck)
            {
                string blogChoice;
                do
                {

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

                            Console.WriteLine("Blog Type elave edin");
                            Console.WriteLine("1 - Programming, 2 - Educational, 3 - Thriller");

                            BlogType blogType = BlogType.Programming;
                            string type;
                            type = Console.ReadLine();

                            switch (type)
                            {
                                case "1":
                                    blogType = BlogType.Educational;
                                    break;
                                case "2":
                                    blogType = BlogType.Educational;
                                    break;
                                case "3":
                                    blogType = BlogType.Thriller;
                                    break;
                                default:
                                    Console.WriteLine("bele blog type yoxdur");
                                    break;
                            }
                            BlogService.AddBlog(new Blog(title.Trim(), desc.Trim(), blogType));
                            break;
                        case "2":
                            string removeStr;
                            int numRemoveId;

                            do
                            {
                                Console.Write("Id daxil edin: ");
                                removeStr = Console.ReadLine();

                            } while (!int.TryParse(removeStr, out numRemoveId));
                            BlogService.RemoveBlog(numRemoveId);
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
                            var allBlogs = BlogService.GetAllBlogs();
                            foreach (Blog blog in allBlogs)
                            {
                                blog.ShowInfo();
                            }
                            break;
                        case "5":
                            Console.Write("axtaris ucun deyer daxil edin: ");
                            string searchVal = Console.ReadLine();

                            var getBlogsByValue = BlogService.GetBlogsByValue(searchVal.Trim());
                            foreach (var blog in getBlogsByValue)
                            {
                                blog.ShowInfo();
                            }
                            break;
                        default:
                            break;
                    }

                } while (blogChoice != "0");
            }

        }
    }
}