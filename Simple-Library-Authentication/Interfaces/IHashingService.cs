using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryAuthentication.Interfaces
{
    /// <summary>
    /// Interface para o serviço de hashing.
    /// Define métodos para criptografar e verificar senhas.
    /// </summary>
    public interface IHashingService
    {
        /// <summary>
        /// Gera o hash de uma senha.
        /// </summary>
        /// <param name="password">Senha em texto puro.</param>
        /// <returns>Senha criptografada (hash).</returns>
        string HashPassword(string password);

        /// <summary>
        /// Verifica se a senha informada corresponde ao hash armazenado.
        /// </summary>
        /// <param name="password">Senha em texto puro.</param>
        /// <param name="hashedPassword">Hash armazenado da senha.</param>
        /// <returns>True se as senhas coincidirem, false caso contrário.</returns>
        bool VerifyPassword(string password, string hashedPassword);
    }
}
