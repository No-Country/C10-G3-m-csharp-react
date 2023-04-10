using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IOwnerRepository> _ownerRepository;
        private readonly Lazy<IEstablishmentRepository> _establishmentRepository;
        private readonly Lazy<IReviewRepository> _reviewRepository;
        private readonly Lazy<IAccessibilityRepository> _accessibilityRepository;
        


        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_repositoryContext));
            _ownerRepository = new Lazy<IOwnerRepository>(() => new OwnerRepository(_repositoryContext));
            _establishmentRepository =
                new Lazy<IEstablishmentRepository>(() => new EstablishmentRepository(_repositoryContext));
            _reviewRepository = new Lazy<IReviewRepository>(() => new ReviewRepository(_repositoryContext));
            _accessibilityRepository = new Lazy<IAccessibilityRepository>(() => new AccessibilityRepository(_repositoryContext));
        }

        public ICategoryRepository Categories =>
            _categoryRepository.Value;

        public IOwnerRepository Owners =>
            _ownerRepository.Value;

        public IEstablishmentRepository Establishments => _establishmentRepository.Value;
        public IReviewRepository Reviews => _reviewRepository.Value;

        public IAccessibilityRepository Accessibilitys => _accessibilityRepository.Value;

        public void Dispose() =>
            _repositoryContext.Dispose();

        public Task SaveAsync() =>
            _repositoryContext.SaveChangesAsync();
    }
}