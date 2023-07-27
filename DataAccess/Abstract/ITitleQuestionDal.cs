using Entity;
using SamiProje.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITitleQuestionDal : IGenericDal<TitleQuestion>
    {
        List<TitleQuestion> GetQuestionsByTitle();
    }
}
