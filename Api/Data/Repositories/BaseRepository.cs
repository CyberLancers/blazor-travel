using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlazorAssemblyTravel.Api.Data.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        internal CruisePriceWatchContext Context;
        internal DbSet<TEntity> DbSet;

        protected BaseRepository(CruisePriceWatchContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<List<TEntity>> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int? take = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            if (orderBy != null)
            {
                if (take != null)
                {
                    var sql = query.ToQueryString();
                    return await orderBy(query).Take(take.Value).ToListAsync();
                }
                return await orderBy(query).ToListAsync();
            }

            if (take != null)
            {
                await query.Take(take.Value).ToListAsync();
            }
            
            return await query.ToListAsync();

        }

        public async Task<TEntity> FirstOrDefault(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            if (orderBy != null)
            {
                return await orderBy(query).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
            }

            return await query.FirstOrDefaultAsync() ?? throw new InvalidOperationException();

        }

        public async Task<TEntity> GetByID(object id)
        {
            return await DbSet.FindAsync(id) ?? throw new InvalidOperationException();
        }

        public async Task Insert(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);

            if (entityToDelete == null)
                return;

            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public async Task InsertOrUpdate(TEntity entity, object id)
        {
            var item = await GetByID(id);
            if (item == null)
            {
                await Insert(entity);
            }
            else
            {
                if (item.Equals(entity))
                    return;

                Context.Entry(item).State = EntityState.Detached;
                Update(entity);
            }
        }
    }
}