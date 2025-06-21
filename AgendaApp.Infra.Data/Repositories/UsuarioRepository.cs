using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Repositories
{
    /// <summary>
    /// Implementação do repositório de usuário
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Usuario usuario)
        {
            _dataContext.Add(usuario);
            _dataContext.SaveChanges();
        }

        public Usuario? Find(Guid id)
        {
            return _dataContext.Set<Usuario>()
                               .Where(u => u.Ativo && u.Id == id)
                               .SingleOrDefault();
        }

        public Usuario? Find(string email, string senha)
        {
            return _dataContext.Set<Usuario>()
                               .Where(u => u.Ativo && u.Email.Equals(email) && u.Senha.Equals(senha))
                               .SingleOrDefault();
        }

        public bool Any(string email)
        {
            return _dataContext.Set<Usuario>()
                               .Where(u => u.Ativo && u.Email.Equals(email))
                               .Any();
        }
    }
}
