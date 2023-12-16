using System.ComponentModel.DataAnnotations;

namespace ProjetoAspNetAT.Models
{
    public class Quadrinho
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome não pode ficar vazio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Autor não pode ficar vazio")]
        public string Autor{ get; set; }
        [Required(ErrorMessage = "Quantidade não pode ficar vazio")]
        public int Quantidade{ get; set; }

    }
}
