using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class User
    {
        private readonly BloggingContext db = new BloggingContext();

        public async Task<Data.Models.User> AuthenticateUser(string username, string password)
        {
            try
            {
                return await db.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
                db.Add(user);
                await db.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
