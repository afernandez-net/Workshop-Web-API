using Camones.Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Camones.Shop.Infrastructure
{
    public class GenericRepository<T, K> : IGenericRepository<T, K> where T : Entity<K>
    {
        private readonly ShopContext context;

        public GenericRepository(ShopContext context)
            => this.context = context;

        public void Delete(T entity)
            => context.Set<T>().Remove(entity);

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
            => context.Set<T>().Where(expression);

        public T Get(K id)
            => context.Set<T>().Find(id);

        public void Insert(T entity)
            => context.Set<T>().Add(entity);

        public void InsertRange(IEnumerable<T> entities)
            => context.Set<T>().AddRange(entities);

        public IEnumerable<T> List()
            => context.Set<T>().ToList();

        public IEnumerable<T> List(Expression<Func<T, bool>> expression)
            => context.Set<T>().Where(expression).ToList();

        public IEnumerable<Tsp> ListSp<Tsp>(string procedure) where Tsp : class
        => context
            .LoadStoreProcedure(procedure)
            .ExecuteStoreProcedure<Tsp>();

        public IQueryable<T> Set()
            => context.Set<T>();

        public void Update(T entity)
            => context.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }
}