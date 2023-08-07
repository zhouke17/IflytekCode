namespace WebApi.Services
{
    public interface IRepositoryWrapper
    {
        IBookRepository Book { get; }
        IAuthorRepository Author { get; }
    }
}
