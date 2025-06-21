using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Contrato de métodos para o repositório de usuário
    /// </summary>
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        Usuario? Find(Guid id);

        Usuario? Find(string email, string senha);

        bool Any(string email);
    }
}
