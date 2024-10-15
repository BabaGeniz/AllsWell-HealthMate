using AllsWellHealthMate.Models;
using AllsWellHealthMate.Repositories;
using AllsWellHealthMate.Services;
using AllsWellHealthMate.DTOs;
using Microsoft.AspNetCore.Components.Forms;
using System.Data;

namespace AllsWellHealthMate.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProviderRepository _providerRepository;


        public UserService(IUserRepository userRepository, IProviderRepository providerRepository)
        {
            _userRepository = userRepository;
            _providerRepository = providerRepository;
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
        public IEnumerable<User> GetListOfUsersByRole(int role)
        {
            if(role == (int)UserRoleEnum.Doctor)
            {
                return _userRepository.GetAllUsers().Where(u => u.UserRole == UserRoleEnum.Doctor.ToString());
            }
            else { 
                return _userRepository.GetAllUsers().Where(u => u.UserRole == UserRoleEnum.Patient.ToString()); 
            }
        }
        public User CreateUser(UserCreateDTO userCreateDTO)
        {
            UserRoleEnum role = (UserRoleEnum)userCreateDTO.UserRole;
            // Mapping of DTO properties to regular properties
            var user = new User
            {
                FirstName = userCreateDTO.FirstName,
                LastName = userCreateDTO.LastName,
                Email = userCreateDTO.Email,
                Password = userCreateDTO.Password,
                UserRole = role.ToString()                
            };
            
            _userRepository.AddUser(user);
            return user;
        }
        
        public Provider CreateProvider(int userId, UserWrapperDTO userWrapperDTO)
        {
            var provider = new Provider
            {
                FirstName = userWrapperDTO.userCreateDTO.FirstName,
                LastName = userWrapperDTO.userCreateDTO.LastName,
                Email = userWrapperDTO.userCreateDTO.Email,
                UserId = userId,   
                Specialization = userWrapperDTO.providerDTO.Specialization,
                HospitalAffiliation = userWrapperDTO.providerDTO.HospitalAffiliation
                    
            };
            _providerRepository.AddProvider(provider);
            return provider;//returns created provider with id
        }
            
        public User UpdateUser(int id, UserDTO userDTO)
        {
            var existingUser = _userRepository.GetUserById(id);
            
            if(existingUser != null)
            {
                // Update the fields from DTO
                existingUser.FirstName = userDTO.FirstName;
                existingUser.LastName = userDTO.LastName;
                existingUser.Email = userDTO.Email;
                existingUser.Age = userDTO.Age;
                existingUser.Password = userDTO.Password;
                existingUser.Height = userDTO.Height;

                _userRepository.UpdateUser(existingUser);  // Save the updated user to the database
            }
            
            return existingUser;
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}
