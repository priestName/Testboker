using Testboker.Model;
using Testboker.IBLL;
using Testboker.IDAL;

namespace Testboker.BLL
{
    public class LogBLL : BaseBLL<Log>, LogIBLL
    {
        public LogBLL(LogIDAL logDAL) : base(logDAL)
        {
        }
    }
}
