using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using Core.Repositories;
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
    }
}
