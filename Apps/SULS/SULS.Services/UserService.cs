﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class UserService : IUserService
    {
        private readonly SULSContext db;

        public UserService(SULSContext db)
        {
            this.db = db;
        }

        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password),
            };
            this.db.Users.Add(user);
            this.db.SaveChanges();
            return user.Id;
        }

        public IEnumerable<string> GetUsernames()
        {
            throw new NotImplementedException();
        }

        public User GetUserOrNull(string username, string password)
        {
            var passwordHash = this.HashPassword(password);
            var user = this.db.Users.FirstOrDefault(
                x => x.Username == username
                && x.Password == passwordHash);
            return user;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
