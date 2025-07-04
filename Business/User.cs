﻿using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace Business
{
    public class User
    {
        private readonly BloggingContext db = new BloggingContext();

        public async Task<bool> AuthenticateUser(string username, string password)
        {
            try
            {
                var user = await db.Users.FirstAsync(x => x.Username == username);
                var hash = BCrypt.Net.BCrypt.HashPassword(password);
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Data.Models.User> GetUser(int id)
        {
            try
            {
                return await db.Users.FirstOrDefaultAsync(x => x.UserId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await db.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
                db.Remove(userToDelete);
                await db.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UpdateUser(Data.Models.User user)
        {
            try
            {
                db.Update(user);
                await db.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> CreateUser(Data.Models.User user)
        {
            try
            {
                //var salt = BCrypt.Net.BCrypt.GenerateSalt();
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = hashedPassword;
                db.Add(user);
                await db.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Data.Models.User? GetUserFromToken(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                var jwtHandler = new JwtSecurityTokenHandler();
                var readableToken = jwtHandler.CanReadToken(token);

                if (readableToken)
                {
                    var t = jwtHandler.ReadJwtToken(token);
                    var claims = t.Claims;
                    var username = claims.Where(x => x.Type == "sub").Select(x => x.Value).FirstOrDefault();
                    return db.Users.FirstOrDefault(x => x.Username == username);

                }
            }

            return null;
        }
    }
}
