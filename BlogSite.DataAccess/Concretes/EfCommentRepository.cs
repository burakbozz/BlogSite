
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using Core.Repositories;
using System.Xml.Serialization;

namespace BlogSite.DataAccess.Concretes;

public class EfCommentRepository : EfRepositoryBase<BaseDbContext,Comment,Guid>,ICommentRepository
{
    public EfCommentRepository(BaseDbContext context) : base(context)
    {
        
    }
}
