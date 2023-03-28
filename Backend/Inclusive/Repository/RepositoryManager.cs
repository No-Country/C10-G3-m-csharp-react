using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IUserRepository> _userRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _userRepository = new Lazy<IUserRepository>(()=>new UserRepository(_context));
        }

        public IUserRepository UserRepository => _userRepository.Value;

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveAsync() => _context.SaveChangesAsync();
    }
}
