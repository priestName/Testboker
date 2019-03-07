using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Testboker.IBLL
{
    public interface BaseIBLL<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="TEntity">添加内容Model</param>
        /// <returns></returns>
        bool Add(TEntity TEntity);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="TEntity">删除条件n => true(查全部) n => n.?=?</param>
        /// <returns></returns>
        bool Remov(TEntity TEntity);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="TEntity">条件n => true(查全部) n => n.?=?</param>
        /// <returns></returns>
        bool Modify(TEntity TEntity);
        /// <summary>
        /// 查询行数
        /// </summary>
        /// <param name="whereLamebda">条件n => true(查全部) n => n.?=?</param>
        /// <returns></returns>
        int GetCount(Func<TEntity, bool> whereLamebda);
        /// <summary>
        /// 查询(Model)
        /// </summary>
        /// <param name="whereLamebda">条件n => true(查全部) n => n.?=?</param>
        /// <returns></returns>
        TEntity GetEntity(Func<TEntity, bool> whereLamebda);
        /// <summary>
        /// 查询(IEnumerable<Model>)
        /// </summary>
        /// <param name="whereLamebda">条件n => true(查全部) n => n.?=?</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLamebda);
        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="SqlText">Sql语句</param>
        /// <returns></returns>
        int QueryBySql(string SqlText);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="pageSize">每页行数</param>
        /// <param name="pageIndex">起始项</param>
        /// <param name="isAsc">排序方式</param>
        /// <param name="whereLamebda">条件n => true(查全部) n => n.?=?</param>
        /// <param name="orderByLamebda">排序方法</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntitiesByPpage<TType>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<TEntity, bool>> whereLamebda, Expression<Func<TEntity, TType>> orderByLamebda);
    }
}
