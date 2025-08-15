using AgendaApp.API.Contexts;
using AgendaApp.API.Entities;

namespace AgendaApp.API.Repositories
{
    /// <summary>
    /// Repositório de dados para categoria.
    /// </summary>
    public class CategoriaRepository
    {
        /// <summary>
        /// Método para consultar todas as categorias no banco de dados.
        /// </summary>
        public List<Categoria> ObterTodos()
        {
            using (var context = new DataContext())
            {
                /*
                 * SELECT * FROM CATEGORIA 
                 * ORDER BY NOME ASC
                 */
                return context
                        .Set<Categoria>()
                        .OrderBy(c => c.Nome)
                        .ToList();
            }
        }

        /// <summary>
        /// Método para verificar se existe uma categoria cadastrada
        /// no banco de dados com o ID informado.
        /// </summary>
        public bool CategoriaExiste(Guid id)
        {
            using (var context = new DataContext())
            {
                return context
                        .Set<Categoria>()
                        .Any(c => c.Id == id);
            }
        }
    }
}
