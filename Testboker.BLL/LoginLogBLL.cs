using Testboker.Model;
using Testboker.IBLL;
using Testboker.IDAL;

namespace Testboker.BLL
{
    public class LoginLogBLL : BaseBLL<LoginLog>, LoginLogIBLL
    {
        public LoginLogBLL(LoginLogIDAL loginLogDAL) : base(loginLogDAL)
        {
        }
    }
}
