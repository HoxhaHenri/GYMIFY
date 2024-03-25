using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.UserDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    internal class UserDomain : DomainBase, IUserDomain
    {
        public UserDomain(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        private IUserRepository userRepository => _unitOfWork.GetRepository<IUserRepository>();
        public IList<UserDTO> GetAllUsers()
        {
            IEnumerable<User> users = userRepository.GetAll();
            var userDTOs = new List<UserDTO>();
            foreach (var user in users)
            {
                var userDTO = new UserDTO()
                {
                    UserId = user.GuidIdentifier,
                    Username = user.Username,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.Role
                };
                userDTOs.Add(userDTO);
            }
            return userDTOs;
        }
        public UserDTO GetUserById(Guid id)
        {
            var user = userRepository.GetById(id);
            if (user == null)
            {
                return null;
            }
            var userDTO = new UserDTO()
            {
                UserId = user.GuidIdentifier,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role
            };
            return userDTO;
        }
    }
}
