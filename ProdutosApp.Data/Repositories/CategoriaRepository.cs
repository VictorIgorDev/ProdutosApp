using ProdutosApp.Data.Contexts;
using ProdutosApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Repositories
{
    public class CategoriaRepository
    {
        public List<Categoria> ObterTodos()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                .Set<Categoria>()
                .OrderBy(c => c.Nome)
                .ToList();

            }
        }
    }
}
