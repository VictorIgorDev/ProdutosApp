﻿using System.ComponentModel.DataAnnotations;

namespace ProdutosApp.Services.Models
{
    public class ProdutosPostRequestModel
    {
        [RegularExpression("^[A-Za-zÀ-Üà-ü0-9\\s]{8,100}$", ErrorMessage = "Por favor, informe um nome válido de 8 a 100 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        public string? Nome { get; set; }

        [Range(0, 999999, ErrorMessage = "Por favor, informe o preço entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        public decimal? Preco { get; set; }

        [Range(0, 9999, ErrorMessage = "Por favor, informe a quantidade entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        public int? Quantidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id da categoria.")]
        public Guid? CategoriaId { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do fornecedor.")]
        public Guid? FornecedorId { get; set; }
    }
}
