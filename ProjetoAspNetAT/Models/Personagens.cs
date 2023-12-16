using System.ComponentModel.DataAnnotations;

namespace ProjetoAspNetAT.Models
{
    public class Personagens
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome não pode ficar vazio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Idade não pode ficar vazio")]
        public int Idade { get; set; }
        [Required(ErrorMessage = "Descrição não pode ficar vazio")]
        public string Descricao { get; set; }
       
    }
}
