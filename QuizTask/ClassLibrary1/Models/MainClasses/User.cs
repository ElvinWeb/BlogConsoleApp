using ClassLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models.MainClasses
{
    public class User
    {
        private static int _count { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        static User()
        {
            _count = 0;
        }

        public User()
        {
            _count++;
            Id = _count;

        }
    }
}
