using DTO;
using SamiProje.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITitleQuestionService : IGenericService<TitleQuestionDto>
    {
        List<TitleQuestionDto> GetQuestionsByTitleID(int id);
    }
}
