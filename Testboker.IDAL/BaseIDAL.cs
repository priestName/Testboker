using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Testboker.IDAL
{
    public interface BaseIDAL<TEntity> where TEntity : class, new()
    {
        void insert(TEntity TEntity);
        void Delete(TEntity TEntity);
        void Update(TEntity TEntity);
        bool SaveChanges();
        int QueryCount(Func<TEntity, bool> whereLamebda);
        TEntity QueryEntity(Func<TEntity, bool> whereLamebda);
        IEnumerable<TEntity> QueryEntities(Func<TEntity, bool> whereLamebda);
        int QueryBySql(string SqlText);
        IEnumerable<TEntity> GetEntitiesByuPage<TType>(int pageSize, int pageIndex, bool isAsc,
        Expression<Func<TEntity, bool>> whereLamebda, Expression<Func<TEntity, TType>> orderByLamebda);
        IEnumerable<TEntity> QueryBySqlData(string SqlText, params object[] parameters);
    }
}
