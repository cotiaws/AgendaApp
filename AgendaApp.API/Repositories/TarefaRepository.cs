using AgendaApp.API.Contexts;
using AgendaApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.API.Repositories
{
    /// <summary>
    /// Repositório de dados para tarefa.
    /// </summary>
    public class TarefaRepository
    {
        /// <summary>
        /// Método para inserir uma nova tarefa no banco de dados.
        /// </summary>
        public void Inserir(Tarefa tarefa)
        {
            using (var context = new DataContext())
            {
                context.Add(tarefa);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Método para atualizar uma tarefa no banco de dados.
        /// </summary>
        public void Atualizar(Tarefa tarefa)
        {
            using (var context = new DataContext())
            {
                context.Update(tarefa);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Método para excluir uma tarefa no banco de dados.
        /// </summary>
        public void Excluir(Tarefa tarefa)
        {
            using (var context = new DataContext())
            {
                context.Remove(tarefa);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Método para consultar tarefas dentro de um período de datas.
        /// </summary>
        public List<Tarefa> ObterPorDatas(DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            using (var context = new DataContext())
            {
                return context
                        .Set<Tarefa>()
                        .Include(t => t.Categoria)
                        .Where(t => t.DataHora >= dataHoraInicio
                                 && t.DataHora <= dataHoraFim)
                        .OrderByDescending(t => t.DataHora)
                        .ToList();
            }
        }

        /// <summary>
        /// Método para consultar 1 tarefa no banco de dados através do ID.
        /// </summary>
        public Tarefa? ObterPorId(Guid id)
        {
            using (var context = new DataContext())
            {
                return context
                        .Set<Tarefa>()
                        .Include(t => t.Categoria)
                        .SingleOrDefault(t => t.Id == id);
            }
        }
    }
}
