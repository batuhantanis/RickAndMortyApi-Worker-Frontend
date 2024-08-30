using System.Linq.Expressions;
using egebilgi_worker.Data.Entitities;
using egebilgi_worker.Data.GenericRepository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace egebilgi_worker.Data.GenericRepository.Concrete;

public class GenericRepository<T> : IGenericRepository<T> where T:class
{
    private readonly workerDbContext _workerDbContext;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(workerDbContext workerDbContext)
    {
        _workerDbContext = workerDbContext;
        _dbSet = workerDbContext.Set<T>();
    }
    public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
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
            _workerDbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}