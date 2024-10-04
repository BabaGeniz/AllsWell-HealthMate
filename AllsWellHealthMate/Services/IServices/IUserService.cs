using System.Collections.Generic;
using AllsWellHealthMate.Models;

namespace AllsWellHealthMate.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
