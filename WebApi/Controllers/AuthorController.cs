using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        //public IAuthorRepository _authorRepository { get; set; }
        public IMapper Mapper { get; }
        public IRepositoryWrapper RepositoryWrapper { get; }
        public AuthorController(IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            Mapper = mapper;
            RepositoryWrapper = repositoryWrapper;
        }


        /// <summary>
        /// 获取所有作者
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<AuthorDto>> GetAuthors()
        {
            //return _authorRepository.GetAuthors().ToList();
            return NotFound();
        }

        /// <summary>
        /// 获取指定作者
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        [HttpGet("{authorId}")]
        public ActionResult<AuthorDto> GetAuthor(Guid authorId)
        {
            //var author = _authorRepository.GetAuthor(authorId);
            //if (author == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return author;
            //}
            return NotFound(authorId);
        }

        [HttpGet("GetAuthorAsyncByAutoMapper")]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthorAsyncByMapper()
        {
            var authors = (await RepositoryWrapper.Author.GetAllAsync()).OrderBy(s => s.Name).ToList();

            if (authors == null)
            {
                return NotFound();
            }
            var authorDtoList = Mapper.Map<IEnumerable<AuthorDto>>(authors);

            return Ok(authorDtoList);

        }

        [HttpPost("CreateAuthorAsyncByMapper")]
        public async Task<ActionResult> CreateAuthorAsyncByMapper(AuthorDto authorForCreationDto)
        {
            var author = Mapper.Map<Author>(authorForCreationDto);
            RepositoryWrapper.Author.Create(author);
            var result = await RepositoryWrapper.Author.SaveAsync();
            if (!result)
            {
                throw new Exception("创建资源author失败！");
            }
            var authorCreated = Mapper.Map<AuthorDto>(author);
            return Ok(authorCreated);
        }
    }
}
