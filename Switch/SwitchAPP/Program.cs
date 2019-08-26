using Microsoft.EntityFrameworkCore;
using Switch.Domain.Entities;
using Switch.Infra.Data.Context;
using System;

namespace SwitchAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuario = new Usuario()
            { Nome = "Alexandre",
                SobreNome = "Ferreira",
                Senha = "teste123",
                Email = "xanderifer1974@gmail.com",
                DataNascimento = DateTime.Now,
                Sexo = Switch.Domain.Enums.SexoEnum.Masculino,
                UrlFoto = "@c:\temp"

                };
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySql("server=localhost;uid=root;pwd=duda0107;database=SwitchDB", m => m.MigrationsAssembly("Switch.Infra.Data"));
            try
            {

                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    dbcontext.Usuarios.Add(usuario);
                    dbcontext.SaveChanges();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();

            }
            Console.WriteLine("Ok");
            Console.ReadKey();
           
        }
    }
}
