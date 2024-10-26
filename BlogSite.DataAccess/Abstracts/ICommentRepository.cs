using BlogSite.Models.Entities;
using Core.Repositories;

namespace BlogSite.DataAccess.Abstracts;

public interface ICommentRepository : IRepository<Comment,Guid>
{
    IEnumerable<Comment> GetCommentsByPost(Guid postId);
    IEnumerable<Comment> GetCommentsByAuthor(string authorId);
}
