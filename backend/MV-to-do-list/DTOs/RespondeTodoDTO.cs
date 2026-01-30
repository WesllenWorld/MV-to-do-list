namespace MV_to_do_list.DTOs
{
    //classe igual à entidade, mas funciona para reduzir o acoplamento
    public class ResponseTodoDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
