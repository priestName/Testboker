using Testboker.Model;
using Testboker.IBLL;
using Testboker.IDAL;

namespace Testboker.BLL
{
    public class ContentListBLL : BaseBLL<ContentList>, ContentListIBLL
    {
        public ContentListBLL(ContentListIDAL contentListDAL) : base(contentListDAL)
        {
        }
    }
}
