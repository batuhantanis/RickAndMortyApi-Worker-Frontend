using System.Linq.Expressions;
using EgeBilgi_Application.GenericRepository;
using EgeBilgi_Domain.Entitities;
using EgeBilgi_Persistence;
using Microsoft.EntityFrameworkCore;

namespace EgeBilgi_Infrastructure.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T:BaseEntity
{
    private readonly EgeBilgiDbContext _egeBilgiDbContext;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(EgeBilgiDbContext egeBilgiDbContext)
    {
        _egeBilgiDbContext = egeBilgiDbContext;
        _dbSet = egeBilgiDbContext.Set<T>();
    }
    public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null,int take = 0,int pageNumber = 0)
    {
        IQueryable<T> query = _dbSet;
        if (expression != null)
        {
            query = query.Where(expression);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        if (take != 0)
        {
            query = query. OrderBy(x => x.Id).Skip(pageNumber * take).Take(take);
        }
        
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null)
    {
        IQueryable<T> query = _dbSet;
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public async Task Insert(T entity)
    {
        await  _dbSet.AddAsync(entity);
    }

    public async Task InsertRange(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task Delete(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);

        }
    }

    public async void DeleteRange(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            var ent = await _dbSet.FindAsync(entity);
            if (ent != null)
            {
                _dbSet.Remove(ent);
            }
        }
    }

    public void Update(T entity)
    {
        if (entity != null)
        {
            _dbSet.Attach(entity);
            _egeBilgiDbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}