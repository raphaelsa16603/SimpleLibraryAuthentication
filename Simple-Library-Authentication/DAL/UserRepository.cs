using SimpleLibraryAuthentication.Models;
using SimpleLibraryAuthentication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLibraryAuthentication.DAL;

namespace SimpleLibraryAuthentication.DAL
{
    /// <summary>
    /// Implementação do repositório de usuários.
    /// Fornece operações para buscar e salvar usuários em um banco de dados MSSQL.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        /// <summary>
        /// Construtor da classe UserRepository.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public UserRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Obtém um usuário pelo nome de usuário.
        /// </summary>
        /// <param name="username">Nome de usuário.</param>
        /// <returns>Objeto do tipo User, ou null se não encontrado.</returns>
        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Username cannot be null or empty.");

            return _context.Users.SingleOrDefault(u => u.Username == username);
        }

        /// <summary>
        /// Salva um usuário no banco de dados.
        /// </summary>
        /// <param name="user">Objeto do tipo User.</param>
        public void SaveUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
