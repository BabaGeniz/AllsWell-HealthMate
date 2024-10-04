using System.Collections.Generic;
using AllsWellHealthMate.Models;
using AllsWellHealthMate.DTOs;

namespace AllsWellHealthMate.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User CreateUser(UserCreateDTO user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
