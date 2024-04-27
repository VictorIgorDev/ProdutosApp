namespace ProdutosApp.Services.Models
{
    public class ProdutosGetResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public CategoriasGetResponseModel? Categoria { get; set; }
        public FornecedoresGetResponseModel? Fornecedor { get; set; }
    }
}
