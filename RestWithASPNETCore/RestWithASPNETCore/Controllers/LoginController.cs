using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETCore.Business;
using RestWithASPNETCore.Data.VO;
using RestWithASPNETCore.Model;
using Tapioca.HATEOAS;

namespace RestWithASPNETCore.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LoginController : Controller
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        // POST api/values
        [AllowAnonymous]
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public object Post([FromBody]UserVO user)
        {
            if (user == null) return BadRequest();
            return _loginBusiness.FindByLogin(user);
        }

    }
}
