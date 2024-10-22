using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories;

public interface IRepository<TEntity,TId> where TEntity : Entity<TId>,new()
{
    List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, bool enableAutoInclude = true);

    TEntity? GetById(TId id);

    TEntity? Update(TEntity entity);

    TEntity? Add(TEntity entity);

    TEntity? Remove(TEntity entity);
}
