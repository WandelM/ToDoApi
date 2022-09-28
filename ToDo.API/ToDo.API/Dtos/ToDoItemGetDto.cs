namespace ToDo.API.Dtos;

/// <summary>
/// ToDoItem Get transfer object
/// </summary>
public class ToDoItemGetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
}
