using Univali.Api.Entities;

namespace Univali.Api.Repositories;

public interface IAuthorRepository
{
    void AddAuthor (Author author);
    void DeleteAuthor (int authorId);
    Task<bool> SaveChangesAsync ();
    Task<Author?> GetAuthorByIdAsync (int authorId);
    Task<Author?> GetAuthorWithCoursesByIdAsync (int authorId);
    Task<bool> AuthorExistsAsync (int authorId);
}