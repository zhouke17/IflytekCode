using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IBookRepository : IRepositoryBase<Book>,IRepositoryBase2<Book,Guid>
    {
        #region 仓储方式一
        IEnumerable<BookDto> GetBooksForAuthor(Guid authorId);
        BookDto GetBookForAuthor(Guid authorId, Guid bookId);
        #endregion



        #region 仓储方式二

        #endregion
    }
}
