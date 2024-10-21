using BlogSite.Models.Dtos.Post.Responses;
using BlogSite.Models.Entities;
using Core.Repositories;


namespace BlogSite.DataAccess.Abstracts;

public interface IPostRepository : IRepository<Post,Guid>
{
    IEnumerable<Post> GetPostsByAuthor(long authorId);
    IEnumerable<Post> GetPostsByCategory(int categoryId);
}
