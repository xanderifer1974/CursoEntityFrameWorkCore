using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Switch.Domain.Entities;
using Switch.Infra.CrossCutting.Logging;
using Switch.Infra.Data.Context;
using System;
using System.Linq;

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
                    dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());
                    //dbcontext.Usuarios.Add(usuario);
                    //dbcontext.SaveChanges();
                    //var resultado = dbcontext.Usuarios.ToList();
                    var resultado = dbcontext.Usuarios.Where(u => u.Nome =="Luciana").ToList();

                    //foreach(var us in resultado)
                    //{

                    //}
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
