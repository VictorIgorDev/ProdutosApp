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
        public IActionResult Put(ProdutosPutRequestModel model)
        {
            try
            {
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.ObterPorId(model.Id.Value);

                if (produto == null)
                    return StatusCode(400, new
                    {
                        Message = "Produto não encontrado.Verifique o ID informado."
                    });

                produto.Nome = model.Nome;
                produto.Preco = model.Preco;
                produto.Quantidade = model.Quantidade;
                produto.CategoriaId = model.CategoriaId;
                produto.FornecedorId = model.FornecedorId;
                produtoRepository.Alterar(produto);

                return StatusCode(200, new
                {
                    Message = "Produto atualizado com sucesso",

                    produto.Id

                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.ObterPorId(id);

                if (produto == null)
                    return StatusCode(400, new
                    {
                        Message = "Produto não encontrado.Verifique o ID informado."
                    });
                produtoRepository.Excluir(produto);
                return StatusCode(200, new
                {
                    Message = "Produto excluído com sucesso",
                    produto.Id
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetResponseModel>), 200)]
        public IActionResult GetAll()
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
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.ObterPorId(id);

                if (produto == null)
                    return NoContent();

                var model = new ProdutosGetResponseModel
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    Categoria = new CategoriasGetResponseModel
                    {
                        Id = produto.Categoria?.Id,
                        Nome = produto.Categoria?.Nome
                    },
                    Fornecedor = new FornecedoresGetResponseModel
                    {
                        Id = produto.Fornecedor?.Id,
                        RazaoSocial = produto.Fornecedor?.RazaoSocial,
                        Cnpj = produto.Fornecedor?.Cnpj
                    }
                };

                return StatusCode(200, model);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

    }
}
