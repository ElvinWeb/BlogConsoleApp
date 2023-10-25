using ClassLibrary1.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public class User
    {
        private static int _count { get; set; }
        private string? _password;
        private string? _name;
        private string? _surname;
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (CheckName.IsValidName(value.Trim()))
                {
                    _name = value;
                }
                else
                {
                    throw new InvalidNameException("Ad deyeri yalnisdi");
                }

            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (CheckSurname.IsValidSurname(value.Trim()))
                {
                    _name = value;
                }
                else
                {
                    throw new InvalidNameException("Soyad deyeri yalnisdi");
                }
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (CheckPassword.Check(value.Trim()))
                {
                    _password = value;
                }
                else
                {
                    throw new InvalidPasswordException("min 8 uzunluqlu , boyuk herfle baslamalidir, icerisinde minimum 1 reqem olmalidir");
                }
            }
        }

        static User()
        {
            _count = 0;
        }

        public User(string name, string surname , string password)
        {
            _count++;
            Id = _count;
            this._name = name;
            this._surname = surname;
            this._password = password; 
            this.Username = this.Name.ToLower() + "." + this.Surname.ToLower();
        }
    }
}
