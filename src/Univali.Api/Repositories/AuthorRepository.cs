using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Univali.Api.DbContexts;
using Univali.Api.Entities;

namespace Univali.Api.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AuthorContext _context;
    private readonly IMapper _mapper;

    public AuthorRepository(AuthorContext authorContext, IMapper mapper)
    {
        _context = authorContext;
        _mapper = mapper;
    }

    public void AddAuthor (Author author)
    {
        _context.Add(author);
    }

    public void DeleteAuthor(int authorId)
    {
        var authorFromDatabase = _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);
        if (authorFromDatabase != null)
            _context.Authors.Remove(authorFromDatabase!);
    }

    public async Task<Author?> GetAuthorByIdAsync(int authorId)
    {
        return await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId);
    }

    public async Task<Author?> GetAuthorWithCoursesByIdAsync(int authorId)
    {
        return await _context.Authors.Include(a => a.Courses).FirstOrDefaultAsync(a => a.AuthorId == 1);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() > 0);
    }

    public async Task<bool> AuthorExistsAsync(int authorId)
    {
        return await _context.Authors.AnyAsync(a => a.AuthorId == authorId);
    }
}