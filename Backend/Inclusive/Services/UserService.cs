using Contracts;
using Entities;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;

        public UserService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<User>> GetUsersAsync(bool trackChanges)
        {
            try
            {
                var users = _repository.UserRepository.GetUsersAsync(trackChanges);
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("Error to require Users");
            }
        }
    }
}
