using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Entities
{
    public class Produto
    {
        #region Propriedades

        public Guid? Id { get; set; } 
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public Guid? CategoriaId { get; set; } 
        public Guid? FornecedorId { get; set; } 

        #endregion

        #region Relacionamentos de composição

        public Categoria? Categoria { get; set; } 
        public Fornecedor? Fornecedor { get; set; } 

        #endregion
    }
}
