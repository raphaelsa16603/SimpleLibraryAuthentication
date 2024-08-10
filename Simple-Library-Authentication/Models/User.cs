using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryAuthentication.Models
{
    /// <summary>
    /// Classe que representa um usuário.
    /// Contém o nome de usuário e o hash da senha.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Nome de usuário.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Hash da senha do usuário.
        /// </summary>
        public string PasswordHash { get; set; }
    }
}
