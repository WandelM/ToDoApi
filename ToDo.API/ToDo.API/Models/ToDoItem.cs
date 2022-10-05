namespace ToDo.API.Models;

/// <summary>
/// Simple to do item
/// </summary>
public class ToDoItem
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserModel User { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Finished { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
}