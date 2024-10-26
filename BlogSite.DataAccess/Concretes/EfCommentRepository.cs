
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace BlogSite.DataAccess.Concretes;

public class EfCommentRepository : EfRepositoryBase<BaseDbContext,Comment,Guid>,ICommentRepository
{
    public EfCommentRepository(BaseDbContext context) : base(context)
    {
        
    }

    public IEnumerable<Comment> GetCommentsByAuthor(string authorId)
    {
        return Context.Comments
            .Where(c => c.UserId == authorId)
            .ToList();
    }

    public IEnumerable<Comment> GetCommentsByPost(Guid postId)
    {
        return Context.Comments
            .Where(c => c.PostId == postId)
            .ToList();
    }
}
