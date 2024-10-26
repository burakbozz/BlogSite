using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Dtos.Post.Responses;
using BlogSite.Models.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Concretes
{
    public class EfPostRepository : EfRepositoryBase<BaseDbContext, Post, Guid>,IPostRepository
    {
        public EfPostRepository(BaseDbContext context) : base(context)
        {
        }

        public IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            return Context.Posts
                .Where(p => p.CategoryId == categoryId)
                .ToList();
                
        }

        public IEnumerable<Post> GetPostsByAuthor(string authorId)
        {
            return Context.Posts
                .Where(p => p.AuthorId == authorId)
                .ToList();
                
        }
    }
}
