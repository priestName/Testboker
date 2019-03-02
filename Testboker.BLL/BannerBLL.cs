using Testboker.Model;
using Testboker.IBLL;
using Testboker.IDAL;

namespace Testboker.BLL
{
    public class BannerBLL : BaseBLL<Banner>, BannerIBLL
    {
        public BannerBLL(BannerIDAL bannerDLL) : base(bannerDLL)
        {
        }
    }
}
