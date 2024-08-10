using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleLibraryAuthentication;
using SimpleLibraryAuthentication.DAL;
using SimpleLibraryAuthentication.Services;
using SimpleLibraryAuthentication.Interfaces;
using System;

namespace SimpleLibraryAuthenticationConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configurando o host e injetando dependências
            var host = CreateHostBuilder(args).Build();

            // Recuperando o serviço de autenticação do contêiner de serviços
            var authService = host.Services.GetRequiredService<AuthenticationService>();

            // Exemplo de registro de usuário
            Console.WriteLine("Registering a new user...");
            Console.Write("Enter username: ");
            var username = Console.ReadLine();

            Console.Write("Enter password: ");
            var password = Console.ReadLine();

            try
            {
                var isRegistered = authService.RegisterUser(username, password);
                if (isRegistered)
                {
                    Console.WriteLine("User registered successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Exemplo de login de usuário
            Console.WriteLine("Logging in the user...");
            Console.Write("Enter username: ");
            var loginUsername = Console.ReadLine();

            Console.Write("Enter password: ");
            var loginPassword = Console.ReadLine();

            var isLoggedIn = authService.LoginUser(loginUsername, loginPassword);
            if (isLoggedIn)
            {
                Console.WriteLine("Login successful!");
            }
            else
            {
                Console.WriteLine("Login failed. Invalid username or password.");
            }
        }

        // Configuração do host e dos serviços
        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // String de conexão para o banco de dados local
                    var connectionString = "Server=localhost;Database=SimpleLibraryAuthenticationDB;Trusted_Connection=True;";

                    // Adicionando o DbContext
                    services.AddDbContext<MyDbContext>(options =>
                        options.UseSqlServer(connectionString));

                    // Injetando os serviços necessários
                    services.AddScoped<IHashingService, SHA256HashingService>();
                    services.AddScoped<IUserRepository, UserRepository>();
                    services.AddScoped<AuthenticationService>();
                });
    }
}
