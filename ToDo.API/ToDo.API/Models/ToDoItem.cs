namespace ToDo.API.Models;

/// <summary>
/// Simple to do item
/// </summary>
public class ToDoItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
}