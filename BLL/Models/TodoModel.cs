namespace BLL.Models
{
    public class TodoModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public bool IsArchived { get; set; }
    }
}
