namespace ToDo.API.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLogIn { get; set; }
        public IList<ToDoItem> ToDoItems { get; set; }
    }
}
