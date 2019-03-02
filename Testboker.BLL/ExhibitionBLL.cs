using Testboker.Model;
using Testboker.IBLL;
using Testboker.IDAL;

namespace Testboker.BLL
{
    public class ExhibitionBLL : BaseBLL<Exhibition>, ExhibitionIBLL
    {
        public ExhibitionBLL(ExhibitionIDAL exhibitionDLL) : base(exhibitionDLL)
        {
        }
    }
}
