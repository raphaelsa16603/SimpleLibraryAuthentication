using SimpleLibraryAuthentication.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SimpleLibraryAuthentication.Services
{
    /// <summary>
    /// Implementação do serviço de hashing usando o algoritmo SHA-256.
    /// </summary>
    public class SHA256HashingService : IHashingService
    {
        /// <summary>
        /// Gera o hash de uma senha usando o algoritmo SHA-256.
        /// </summary>
        /// <param name="password">Senha em texto puro.</param>
        /// <returns>Senha criptografada (hash).</returns>
        public string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be null or empty.");

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Verifica se a senha informada corresponde ao hash armazenado.
        /// </summary>
        /// <param name="password">Senha em texto puro.</param>
        /// <param name="hashedPassword">Hash armazenado da senha.</param>
        /// <returns>True se as senhas coincidirem, false caso contrário.</returns>
        public bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
                throw new ArgumentException("Password and hashedPassword cannot be null or empty.");

            string hashedInput = HashPassword(password);
            return string.Equals(hashedInput, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
