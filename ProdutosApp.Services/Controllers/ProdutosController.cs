using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Data.Entities;
using ProdutosApp.Data.Repositories;
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
            try
            {
                var produto = new Produto()
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Preco = model.Preco,
                    Quantidade = model.Quantidade,
                    CategoriaId = model.CategoriaId,
                    FornecedorId = model.FornecedorId

                };

                var produtoRepository = new ProdutoRepository();
                produtoRepository.Inserir(produto);

                return StatusCode(201, new
                {
                    Message = "Produto cadastrado com sucesso",
                    produto.Id

                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
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
            try
            {
                var produtoRepository = new ProdutoRepository();
                var produtos = produtoRepository.ObterTodos();
                var response = new List<ProdutosGetResponseModel>();
                foreach (var item in produtos)
                {
                    response.Add(new ProdutosGetResponseModel
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Preco = item.Preco,
                        Quantidade = item.Quantidade,
                        Categoria = new CategoriasGetResponseModel

                        {
                            Id = item.Categoria?.Id,
                            Nome = item.Categoria?.Nome

                        },

                        Fornecedor = new FornecedoresGetResponseModel

                        {
                            Id = item.Fornecedor?.Id,

                            RazaoSocial = item.Fornecedor?.RazaoSocial,
                            Cnpj = item.Fornecedor?.Cnpj

                        }
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
