using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Services
{
    public class BookRepository : RepositoryBase<Book,Guid>, IBookRepository
    {
        #region 仓储方式一
        public BookDto GetBookForAuthor(Guid authorId, Guid bookId)
        {
            return LibraryMockData.Current.Books.FirstOrDefault(b => b.AuthorId == authorId && b.Id == bookId);
        }
        public IEnumerable<BookDto> GetBooksForAuthor(Guid authorId)
        {
            return LibraryMockData.Current.Books.Where(b => b.AuthorId == authorId).ToList();
        }
        #endregion



        #region 仓储方式二
        public BookRepository(DbContext dbContext):base(dbContext)
        {

        }
        #endregion
    }
}
