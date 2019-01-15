using DDD.NetCore.Domain.Repository;
using DDD.NetCore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace DDD.NetCore.Infrastructure.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly StudyContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(StudyContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }


        public System.Linq.IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(GetById(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
