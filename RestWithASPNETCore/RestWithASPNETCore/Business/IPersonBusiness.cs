using RestWithASPNETCore.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNETCore.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
