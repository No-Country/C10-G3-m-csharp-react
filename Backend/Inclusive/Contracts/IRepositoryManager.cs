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
        IOwnerRepository Owners { get; }
        IEstablishmentRepository Establishments { get; }
        IReviewRepository Reviews { get; }
        Task SaveAsync();
    }
}