namespace ToDo.API.Dtos
{
    public class UserGetDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLogIn { get; set; }
    }
}
