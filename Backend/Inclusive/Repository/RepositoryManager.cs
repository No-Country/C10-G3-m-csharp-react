using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ICategoryImageRepository> _categoryImageRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_repositoryContext));
            _categoryImageRepository =
                new Lazy<ICategoryImageRepository>(() => new CategoryImageRepository(_repositoryContext));
        }

        public ICategoryRepository Categories => _categoryRepository.Value;
        public ICategoryImageRepository CategoryImages => _categoryImageRepository.Value;

        public void Dispose() => _repositoryContext.Dispose();

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}