﻿using ClassLibrary.Exceptions;
using ClassLibrary.Models.DataBase;
using ClassLibrary.Models.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models.Services
{
    public static class UserService
    {

        public static void Register(string name, string surname, string password)
        {

            if (string.IsNullOrWhiteSpace(name) || name.Any(char.IsDigit))
            {
                throw new InvalidNameException("Ad deyeri sehvdir!!");
            }

            if (string.IsNullOrWhiteSpace(surname) || surname.Any(char.IsDigit))
            {
                throw new InvalidSurNameException("Soyad deyeri sehvdir!!");
            }

            if (password.Length < 8 || !password.Any(char.IsDigit) || !char.IsUpper(password[0]) || string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidPasswordException("Password deyeri sehvdir!!");
            }

            string username = $"{name.ToLower()}.{surname.ToLower()}";

            User newUser = new User
            {
                Name = name,
                Surname = surname,
                Username = username,
                Password = password
            };

            BlogDataBase.Users.Add(newUser);
        }

        public static bool Login(string username, string password)
        {
            if (username == null || password == null)
            {
                return false;
            }
            User user = BlogDataBase.Users.FirstOrDefault(user => user.Username == username && user.Password == password);

            return user != null;
        }
    }
}
