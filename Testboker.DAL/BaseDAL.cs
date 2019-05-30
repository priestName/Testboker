using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Testboker.IDAL;
using Testboker.Model;

namespace Testboker.DAL
{
    public class BaseDAL<TEntity> : BaseIDAL<TEntity> where TEntity : class, new()
    {
        private TestBoker _dbContext = DbContextFactory.GetIntance();
        private DbSet<TEntity> _dbSet;
        public BaseDAL()
        {
            _dbSet = _dbContext.Set<TEntity>();
        }
        public void Delete(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            _dbSet.Remove(tEntity);
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges()>0;
        }
        public void Update(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            //更改实体状态为已修改
            _dbContext.Entry(tEntity).State = EntityState.Modified;
        }
        public void insert(TEntity tEntity)
        {
            _dbSet.AddOrUpdate(tEntity);
        }
        public TEntity QueryEntity(Expression<Func<TEntity, bool>> whereLamebda)
        {
            return _dbSet.FirstOrDefault(whereLamebda);
        }
        public IEnumerable<TEntity> QueryEntities(Expression<Func<TEntity, bool>> whereLamebda)
        {
            return _dbSet.Where(whereLamebda);
        }
        public IEnumerable<TEntity> GetEntitiesByuPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, bool>> whereLamebda, Expression<Func<TEntity, TType>> orderByLamebda)
        {
            //查询
            var result = _dbSet.Where(whereLamebda);
            //排序
            result = isAsc ? result.OrderBy(orderByLamebda) : result.OrderByDescending(orderByLamebda);
            //分页
            var offset = (pageIndex - 1) * pageSize;//开始项索引
            result=result.Skip(offset).Take(pageSize);
            return result;
        }

        public int QueryCount(Expression<Func<TEntity, bool>> whereLamebda)
        {
            return _dbSet.Count(whereLamebda);
        }
        public int QueryBySql(string SqlText)
        {
            return _dbContext.Database.ExecuteSqlCommand(SqlText);
        }
        public IEnumerable<TEntity> QueryBySqlData(string SqlText, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<TEntity>(SqlText, parameters).AsQueryable<TEntity>().ToList();
        }
        
    }
}
