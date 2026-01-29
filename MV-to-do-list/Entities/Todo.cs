using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MV_to_do_list.Entities
{
    public class Todo
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public bool Status { get; set; } /* False = Pendente, True = Concluída
        Em caso de um crescimento do app, vale considerar Status ser um Enum para comportar outros Status
        ex: "Em andamento", "Cancelada", "Parcialmente Concluído", etc. */
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
