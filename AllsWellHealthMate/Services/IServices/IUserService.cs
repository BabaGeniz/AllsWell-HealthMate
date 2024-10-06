using System.Collections.Generic;
using AllsWellHealthMate.Models;
using AllsWellHealthMate.DTOs;

namespace AllsWellHealthMate.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByFirstName(string name);
        User CreateUser(UserCreateDTO userCreateDTO);
        Provider CreateProvider(int userId, UserWrapperDTO userWrapperDTO);
        User UpdateUser(int id, UserDTO userDTO);
        void DeleteUser(int id);
    }
}
