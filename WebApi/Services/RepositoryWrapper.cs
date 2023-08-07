using WebApi.Entities;

namespace WebApi.Services
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IAuthorRepository authorRepository;
        private IBookRepository bookRepository;
        public IAuthorRepository Author => authorRepository ?? new AuthorRepository(LibraryDbContext);
        
        public IBookRepository Book => bookRepository ?? new BookRepository(LibraryDbContext);

        public LibraryDbContext LibraryDbContext { get; }

        public RepositoryWrapper(LibraryDbContext libraryDbContext)
        {
            LibraryDbContext = libraryDbContext;
        }
    }
}
