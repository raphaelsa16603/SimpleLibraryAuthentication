using SimpleLibraryAuthentication.Models;
using SimpleLibraryAuthentication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryAuthentication.Services
{
    /// <summary>
    /// Serviço de autenticação que lida com o registro e login de usuários.
    /// </summary>
    public class AuthenticationService
    {
        private readonly IHashingService _hashingService;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Construtor da classe AuthenticationService.
        /// </summary>
        /// <param name="hashingService">Serviço de hashing.</param>
        /// <param name="userRepository">Repositório de usuários.</param>
        public AuthenticationService(IHashingService hashingService, IUserRepository userRepository)
        {
            _hashingService = hashingService ?? throw new ArgumentNullException(nameof(hashingService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        /// <summary>
        /// Registra um novo usuário no sistema.
        /// </summary>
        /// <param name="username">Nome de usuário.</param>
        /// <param name="password">Senha em texto puro.</param>
        /// <returns>True se o registro for bem-sucedido, false caso contrário.</returns>
        public bool RegisterUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentException("Username and password cannot be null or empty.");

            var existingUser = _userRepository.GetUserByUsername(username);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Username already exists.");
            }

            var hashedPassword = _hashingService.HashPassword(password);
            var user = new User { Username = username, PasswordHash = hashedPassword };
            _userRepository.SaveUser(user);
            return true;
        }

        /// <summary>
        /// Autentica um usuário no sistema.
        /// </summary>
        /// <param name="username">Nome de usuário.</param>
        /// <param name="password">Senha em texto puro.</param>
        /// <returns>True se a autenticação for bem-sucedida, false caso contrário.</returns>
        public bool LoginUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentException("Username and password cannot be null or empty.");

            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                return false;
            }

            return _hashingService.VerifyPassword(password, user.PasswordHash);
        }
    }

}
