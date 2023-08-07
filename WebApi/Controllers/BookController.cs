using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/authors/{authorId}/books")]
    [ApiController]
    public class BookController:ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        public BookController(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// 获取指定作者的所有书籍
        /// </summary>
        /// <param name="authorId">作者id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<BookDto>> GetBooks(Guid authorId)
        {
            if (!_authorRepository.IsAuthorExists(authorId))
            {
                return NotFound();
            }
            return _bookRepository.GetBooksForAuthor(authorId).ToList();
        }

        /// <summary>
        /// 获取指定作者的指定书籍
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("{bookId}")]
        public ActionResult<BookDto> GetBook(Guid authorId,Guid bookId)
        {
            if (!_authorRepository.IsAuthorExists(authorId))
            {
                return NotFound();
            }
            var res = _bookRepository.GetBookForAuthor(authorId, bookId);
            if (res == null )
            {
                return NotFound();
            }
            return res;
        }
    }
}
