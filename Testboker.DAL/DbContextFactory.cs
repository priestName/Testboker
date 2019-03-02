using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using Testboker.Model;

namespace Testboker.DAL
{
    class DbContextFactory
    {
        public static TestBoker GetIntance()
        {
            //CallContext是线程槽，一个请求就是一个线程，如果数据上下文存在，就直接从线程槽里拿出来
            var _dbContext = CallContext.GetData("dbContext") as TestBoker;
            //如果数据上下文不存在，就创建一个，放进线程槽，供线程下次操作使用
            if (_dbContext == null)
            {
                _dbContext = new TestBoker();
                CallContext.SetData("dbContext", _dbContext);
            }

            return _dbContext;
        }
    }
}
