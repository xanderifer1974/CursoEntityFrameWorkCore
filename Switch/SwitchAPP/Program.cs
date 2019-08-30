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
                    //=====================================
                    //----Adiciona um usuário na tabela ---
                    //dbcontext.Usuarios.Add(usuario);
                    //dbcontext.SaveChanges();
                    //====================================
                    // LISTA TODOS OS USUÁRIOS 
                    //----------------------------------------
                    //var resultado = dbcontext.Usuarios.ToList();
                    //==============================================
                    //CONSULTA USUÁRIO POR NOME
                    //===================================================
                    //var resultado = dbcontext.Usuarios.Where(u => u.Nome =="Luciana").ToList();
                    //foreach(var us in resultado)
                    //{

                    //}
                    //============================================================================
                    //Cria um usuário novo e consulta através do método First. Em seguida associa a uma variável
                    //que cria uma nova instância do usuário
                    //====================================================================================
                    //var usuarioNovo = CriarUsuario("Natan","Spinelli");
                    //dbcontext.Add(usuarioNovo);
                    //dbcontext.SaveChanges();
                    //Lista o registro encontrado, porém se não encontrar dispara um exceção
                    //===========================================================================
                    //var usuarioRetorno = dbcontext.Usuarios.First(u => u.Nome == "Natan");
                    //==========================================================================
                    //Lista a primeira ocorrência procurada, senão encontrar lista nulo.
                    //var usuarioRetorno = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "Natan2");

                    //if (usuarioRetorno == null)
                    //{
                    //    Console.WriteLine("Usuário não encontrado");
                    //}

                    //Console.WriteLine("Nome do usuário criado ==>  " + usuarioRetorno.Nome);
                    //===============================================================================
                    // ************** DELETANDO UM USUÁRIO NA BASE ************************************
                    //===============================================================================
                    //var usuarioPai = CriarUsuario("Nilson", "Ferreira");
                    //var usuarioMae = CriarUsuario("Nilson", "Ferreira");

                    //dbcontext.Usuarios.Add(usuarioPai);
                    //dbcontext.Usuarios.Add(usuarioMae);
                    //dbcontext.SaveChanges();

                    //var totalUsuario = dbcontext.Usuarios.Count(u => u.Nome == "Nilson");
                    //var DelUsuario = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "Nilson");
                    ////dbcontext.Usuarios.Remove(DelUsuario); //Alternativa 1
                    //dbcontext.Remove<Usuario>(DelUsuario); //Alternativa 2
                    ////dbcontext.SaveChanges();
                    //=================================================================================
                    //********** ATUALIZANDO UM REGISTRO NA BASE DE DADOS *****************************
                    //=================================================================================
                    //var UserNatan = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "Natan");
                    //UserNatan.Senha = "natan123"; 
                    //dbcontext.Update<Usuario>(UserNatan); //Dessa forma, atualiza todas as colunas da tabela. Não informando este comando, atualiza somente senha.
                    //dbcontext.SaveChanges();
                    ///==========================================================================================
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
        /// <summary>
        /// Método para criar usuário
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public static Usuario CriarUsuario(string nome, string sobrenome)
        {
            return new Usuario()
            {
                Nome = nome,
                SobreNome = sobrenome,
                Senha = "abc123",
                Email = "usuario@teste.com",
                DataNascimento = DateTime.Now,
                Sexo = Switch.Domain.Enums.SexoEnum.Masculino,
                UrlFoto = @"c:\temp"
            };
        }
    }
}
