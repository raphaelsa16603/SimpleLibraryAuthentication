using SimpleLibraryAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryAuthentication.Interfaces
{
    /// <summary>
    /// Interface para o repositório de usuários.
    /// Define métodos para obter e salvar usuários no banco de dados.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Obtém um usuário pelo nome de usuário.
        /// </summary>
        /// <param name="username">Nome de usuário.</param>
        /// <returns>Objeto do tipo User.</returns>
        User GetUserByUsername(string username);

        /// <summary>
        /// Salva um usuário no banco de dados.
        /// </summary>
        /// <param name="user">Objeto do tipo User.</param>
        void SaveUser(User user);
    }
}
