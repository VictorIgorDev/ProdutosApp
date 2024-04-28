using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Data.Repositories;
using ProdutosApp.Services.Models;

namespace ProdutosApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriasGetResponseModel>), 200)]

        public IActionResult Get()
        {
            try
            {
                var categoriaRepository = new CategoriaRepository();
                var categorias = categoriaRepository.ObterTodos();
                var response = new List<CategoriasGetResponseModel>();
                foreach (var item in categorias)
                {
                    response.Add(new CategoriasGetResponseModel
                    {
                        Id = item.Id,
                        Nome = item.Nome

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
