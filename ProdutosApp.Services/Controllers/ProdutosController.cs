using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Services.Models;

namespace ProdutosApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ProdutosPostRequestModel model)
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetResponseModel>), 200)]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
