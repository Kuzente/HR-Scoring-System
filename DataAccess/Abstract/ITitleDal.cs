using Entity;
using SamiProje.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITitleDal : IGenericDal<Title>
    {
        List<Title> GetTitlesWithDepartmant();
        Title GetTitleWithDepartmant(int id);
        void UpdateTitle(Title title);
    }
}
