using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Services
{
    public class AuthorRepository : RepositoryBase<Author, Guid>, IAuthorRepository
    {
        #region 仓储模式一
        public AuthorDto GetAuthor(Guid authorId)
        {
            var author = LibraryMockData.Current.Authors.FirstOrDefault(au => au.Id == authorId);
            return author;
        }
        public IEnumerable<AuthorDto> GetAuthors()
        {
            return LibraryMockData.Current.Authors;
        }
        public bool IsAuthorExists(Guid authorId)
        {
            return LibraryMockData.Current.Authors.Any(au => au.Id == authorId);
        }
        #endregion


        #region 仓储方式二
        public AuthorRepository(DbContext dbContext) : base(dbContext)
        {

        }
        #endregion
    }
}
