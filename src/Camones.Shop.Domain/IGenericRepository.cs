namespace Camones.Shop.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T, K> where T : Entity<K>
    {
        T Get(K id);

        IEnumerable<T> List();

        IQueryable<T> Set();

        IEnumerable<T> List(Expression<Func<T, bool>> expression);

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        void Insert(T entity);

        void InsertRange(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);

        IEnumerable<Tsp> ListSp<Tsp>(string procedure) where Tsp : class;
    }
}