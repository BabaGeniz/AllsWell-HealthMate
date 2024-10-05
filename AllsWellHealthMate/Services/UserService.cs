using AllsWellHealthMate.Models;
using AllsWellHealthMate.Repositories;
using AllsWellHealthMate.Services;
using AllsWellHealthMate.DTOs;

namespace AllsWellHealthMate.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
        public User GetUserByFirstName(string name)
        {
            return _userRepository.GetUserByName(name);
        }
        public User CreateUser(UserCreateDTO userCreateDTO)
        {
            // Mapping of DTO properties to regular properties
            var user = new User
            {
                FirstName = userCreateDTO.FirstName,
                LastName = userCreateDTO.LastName,
                Email = userCreateDTO.Email,

            };
            _userRepository.AddUser(user);
            return user; //returns created user with id
        }

        public User UpdateUser(int id, UserDTO userDTO)
        {
            var existingUser = _userRepository.GetUserById(id);
            

            // Update the fields from DTO
            existingUser.FirstName = userDTO.FirstName;
            existingUser.LastName = userDTO.LastName;
            existingUser.Email = userDTO.Email;
            existingUser.Age = userDTO.Age;
            existingUser.Height = userDTO.Height;

            _userRepository.UpdateUser(existingUser);  // Save the updated user to the database
            return (existingUser);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}
