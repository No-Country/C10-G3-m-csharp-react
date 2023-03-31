using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICategoryRepository> _categoryRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_repositoryContext));
        }

        public ICategoryRepository Categories => _categoryRepository.Value;
        public void Dispose() => _repositoryContext.Dispose();
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}