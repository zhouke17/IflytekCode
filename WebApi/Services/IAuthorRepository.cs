using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Services
{

    public interface IAuthorRepository:IRepositoryBase<Author>,IRepositoryBase2<Author,Guid>
    {
        #region 仓储方式一
        IEnumerable<AuthorDto> GetAuthors();
        AuthorDto GetAuthor(Guid authorId);
        bool IsAuthorExists(Guid authorId);
        #endregion

        #region 仓储方式二

        #endregion

    }

}
