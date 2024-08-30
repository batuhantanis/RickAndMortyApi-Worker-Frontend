﻿using System.Linq.Expressions;

namespace EgeBilgi_Application.GenericRepository;

public interface IGenericRepository<T> where T:class
{
    Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        List<string> includes = null,
        int take = 0,
        int pageNumber = 0
        );
    Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null);
    Task  Insert(T entity);
    Task InsertRange(IEnumerable<T> entities);
    Task Delete(int id);
    void DeleteRange(IEnumerable<T> entities);
    void Update(T entity);
}