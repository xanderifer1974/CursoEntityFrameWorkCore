using Switch.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Switch.Domain.Entities
{
   public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string UrlFoto { get; set; }
        public SexoEnum Sexo { get; set; }
        public virtual Identificacao Identificacao { get; set; }
        public virtual ICollection<Postagem> Postagens { get; set; } //No lado do relacionamento de um para muitos , na parte muito e necessário utilizar o Icollection na classe para muitos.       

    }
}
