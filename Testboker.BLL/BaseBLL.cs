using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Testboker.IBLL;
using Testboker.IDAL;

namespace Testboker.BLL
{
    public class BaseBLL<TEntity> : BaseIBLL<TEntity> where TEntity : class, new()
    {
        private BaseIDAL<TEntity> _baseDLL;

        public BaseBLL(BaseIDAL<TEntity> baseDLL)
        {
            _baseDLL = baseDLL;
        }

        public bool Add(TEntity tEntity)
        {
            _baseDLL.insert(tEntity);
            return _baseDLL.SaveChanges();
        }
        public bool Modify(TEntity tEntity)
        {
            _baseDLL.Update(tEntity);
            return _baseDLL.SaveChanges();
        }
        public bool Remov(TEntity tEntity)
        {
            _baseDLL.Delete(tEntity);
            return _baseDLL.SaveChanges();
        }
        public TEntity GetEntity(Expression<Func<TEntity, bool>> whereLamebda)
        {
            return _baseDLL.QueryEntity(whereLamebda);
        }
        public IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, bool>> whereLamebda)
        {
            return _baseDLL.QueryEntities(whereLamebda);
        }
        public IEnumerable<TEntity> GetEntitiesByPpage<TType>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<TEntity, bool>> whereLamebda, Expression<Func<TEntity, TType>> orderByLamebda)
        {
            return _baseDLL.GetEntitiesByuPage(pageSize, pageIndex, isAsc, whereLamebda, orderByLamebda);
        }
        public int GetCount(Expression<Func<TEntity, bool>> whereLamebda)
        {
            return _baseDLL.QueryCount(whereLamebda);
        }
        public int QueryBySql(string SqlText)
        {
            return _baseDLL.QueryBySql(SqlText);
        }
        public IEnumerable<TEntity> QueryBySqlData(string SqlText, params object[] parameters)
        {
            return _baseDLL.QueryBySqlData(SqlText, parameters);
        }
    }
}
