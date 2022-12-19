namespace DAL.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public bool IsArchived { get; set; }
    }
}
