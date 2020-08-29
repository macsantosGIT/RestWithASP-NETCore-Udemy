using RestWithASPNETCore.Data.VO;
using RestWithASPNETCore.Model;

namespace RestWithASPNETCore.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(UserVO user);
    }
}
