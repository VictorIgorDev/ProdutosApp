using ProdutosApp.Data.Contexts;
using ProdutosApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Repositories
{
    public class FornecedorRepository
    {
        public List<Fornecedor> ObterTodos()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                .Set<Fornecedor>()
                .OrderBy(f => f.RazaoSocial)
                .ToList(); 
            }
        }
    }
}
