using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Contrato de métodos para o repositório de tarefa
    /// </summary>
    public interface ITarefaRepository
    {
        void Add(Tarefa tarefa);

        void Update(Tarefa tarefa);

        void Delete(Guid id);

        List<Tarefa>? FindAll(DateOnly dataMin, DateOnly dataMax, Guid usuarioId);

        Tarefa? FindById(Guid id, Guid usuarioId);
    }
}

