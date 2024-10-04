
using System.Collections.Generic;
using AllsWellHealthMate.Models;

namespace AllsWellHealthMate.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        public User? GetUserByName(string firstname);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
