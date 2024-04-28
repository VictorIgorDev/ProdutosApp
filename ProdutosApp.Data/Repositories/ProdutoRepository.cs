using ProdutosApp.Data.Contexts;
using ProdutosApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Repositories
{
    public class ProdutoRepository
    {
        public void Inserir(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(produto);
                dataContext.SaveChanges();
            }
        }
        public void Alterar(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(produto);
                dataContext.SaveChanges();
            }
        }

        public void Excluir(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(produto);
                dataContext.SaveChanges();
            }
        }

        public List<Produto> ObterTodos()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                .Set<Produto>()
                .OrderBy(p => p.Nome)
                .ToList();

            }
        }
        public Produto? ObterPorId(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                .Set<Produto>()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            }
        }
    }
}
