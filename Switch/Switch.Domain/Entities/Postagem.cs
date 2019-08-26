using System;

namespace Switch.Domain.Entities
{
    public class Postagem
    {
        public int Id { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Texto { get; set; }
        public int UsuarioId { get; set; } //No relacionamento 1 para muitos, na classe que a relação é de um é preciso colocar o id e a classe a ser relacionada.
        public virtual Usuario Usuario { get; set; } //Propriedade de navegação apontando para usuário.
        public int GrupoId { get; set; }
        public virtual Grupo Grupo { get; set;}
        public string UrlConteudo { get; set; }

    }
}
