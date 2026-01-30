using System.ComponentModel.DataAnnotations;

namespace MV_to_do_list.DTOs
{
    public class CreateTodoDTO
    {
        //permite todos com o mesmo nome
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres")]
        [MaxLength(50, ErrorMessage = "O nome pode ter no máximo 50 caracteres")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(250, ErrorMessage = "A descrição pode ter no máximo 250 caracteres")]
        public string Description { get; set; } = string.Empty;
        //public bool Status { get; set; } não criar um todo concluído
    }
}
