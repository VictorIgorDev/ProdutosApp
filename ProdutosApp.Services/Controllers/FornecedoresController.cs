using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Data.Repositories;
using ProdutosApp.Services.Models;

namespace ProdutosApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<FornecedoresGetResponseModel>), 200)]

        public IActionResult Get()
        {
            try
            {
                var fornecedorRepository = new FornecedorRepository();
                var fornecedores = fornecedorRepository.ObterTodos();
                var response = new List<FornecedoresGetResponseModel>();
                foreach (var item in fornecedores)
                {
                    response.Add(new FornecedoresGetResponseModel
                    {
                        Id = item.Id,

                        RazaoSocial = item.RazaoSocial,
                        Cnpj = item.Cnpj

                    });
                }

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
