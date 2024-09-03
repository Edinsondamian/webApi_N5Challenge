using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Infrastructure.Repository.Context;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext Context;
    protected readonly DbSet<TEntity> _entity;

    public Repository(DbContext context)
    {
        Context = context;
        _entity = Context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity) => await _entity.AddAsync(entity);

    public async Task<List<TEntity>> GetAllAsync() => await _entity.ToListAsync();

    public async Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> expression)
        => await _entity.AsNoTracking().Where(expression).FirstOrDefaultAsync();

    public void Modify(TEntity item)
    {
        if (Context.Entry(item).State == EntityState.Detached)
        {
            _entity.Attach(item);
            Context.Entry(item).State = EntityState.Modified;
        }

        _entity.Update(item);
    }
}
