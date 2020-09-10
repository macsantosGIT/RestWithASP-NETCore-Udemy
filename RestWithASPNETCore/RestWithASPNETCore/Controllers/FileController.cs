using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETCore.Business;
using RestWithASPNETCore.Data.VO;
using RestWithASPNETCore.Model;
using Swashbuckle.AspNetCore.SwaggerGen;
using Tapioca.HATEOAS;

namespace RestWithASPNETCore.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class FileController : Controller
    {
        private IFileBusiness _fileBusiness;

        public FileController(IFileBusiness fileBusiness)
        {
            _fileBusiness = fileBusiness;
        }

        // GET api/values
        [HttpGet]
        [SwaggerResponse((200), Type = typeof(byte []))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetPDFFile()
        {
            byte[] buffer = _fileBusiness.GetPDFFile();
            if(buffer != null)
            {
                HttpContext.Response.ContentType = "application/pdf";
                HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
                HttpContext.Response.Body.Write(buffer, 0, buffer.Length);
            }

            return new ContentResult();
        }

    }
}
