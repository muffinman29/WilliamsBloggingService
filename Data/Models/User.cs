﻿namespace Data.Models
{
    public class User
    {
        public required int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        public required ICollection<Blog> Blogs { get; set; }

    }
}
