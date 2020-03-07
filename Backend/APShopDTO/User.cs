using System;
using System.Collections.Generic;
using System.Text;

namespace APShopDTO
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        //public User(long id, string username, string password, string role)
        //{
        //    Id = id;
        //    this.username = username;
        //    this.password = password;
        //    this.role = role;
        //}
    }
}
