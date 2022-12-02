using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class AtividadesModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o tipo da atividade!")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Digite a Disciplina!")]
        public string Disciplina { get; set; }
        [Required(ErrorMessage = "Digite a data limite!")]
        public string Data { get; set; }


    }
}
