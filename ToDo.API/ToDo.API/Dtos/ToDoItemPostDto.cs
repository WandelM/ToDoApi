namespace ToDo.API.Dtos
{
    public class ToDoItemPostDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
