using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager : IDisposable
    {
        ICategoryRepository Categories { get; }
        ICategoryImageRepository CategoryImages { get; }
        Task SaveAsync();
    }
}