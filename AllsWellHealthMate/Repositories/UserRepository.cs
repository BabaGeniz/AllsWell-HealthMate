
using System.Collections.Generic;
using System.Linq;
using AllsWellHealthMate.Data;
using AllsWellHealthMate.Models;
using AllsWellHealthMate.Repositories;

namespace AllsWellHealthMate.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HealthMateDbContext _context;

        public UserRepository(HealthMateDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        public User GetUserByName(string firstname)
        {
            return _context.Users.First(u => u.FirstName == firstname);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user); // Add user to the context
            _context.SaveChanges(); // Saving changes to generate the Id
        }

        // Update an existing user
        public void UpdateUser(User user)
        {
            _context.Users.Update(user); // Update user in the context
            _context.SaveChanges(); // Save changes to the database
        }

        // Delete a user by ID
        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id); // Find user by ID
            if (user != null)
            {
                _context.Users.Remove(user); // Remove user from the context
                _context.SaveChanges(); // Save changes to the database
            }
        }
    }
}
