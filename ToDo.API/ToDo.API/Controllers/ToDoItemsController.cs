using Microsoft.AspNetCore.Mvc;
using ToDo.API.Dtos;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IReadOnlyList<ToDoItemGetDto> _items;

        public ToDoItemsController()
        {
            _items = new List<ToDoItemGetDto>()
            {
                new ToDoItemGetDto()
                {
                    Id = Guid.Parse("e7bd292e-405d-4845-98e6-007aa08eef98"),
                    Name = "Mock Item 1",
                    CreatedDate = DateTime.Now,
                    Description = "This is simple description 1",
                    DueDate = DateTime.Now.AddYears(2)
                },
                new ToDoItemGetDto()
                {
                    Id = Guid.Parse("b4960efd-00a1-4a80-834e-ba307f0e1592"),
                    Name = "Mock Item 2",
                    CreatedDate = DateTime.Now.AddDays(-5),
                    Description = "This is simple description 2",
                    DueDate = DateTime.Now.AddYears(2)
                },
                new ToDoItemGetDto()
                {
                    Id = Guid.Parse("a6960efd-00a1-4a80-834e-ba307f0e1592"),
                    Name = "Mock Item 3",
                    CreatedDate = DateTime.Now.AddDays(-10),
                    Description = "This is simple description 3",
                    DueDate = DateTime.Now.AddYears(2)
                }
            };
        }

        [HttpGet("item")]
        [Produces(typeof(ToDoItemGetDto))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<ToDoItemGetDto> GetToDoItem([FromQuery]Guid itemId)
        {
            if (itemId.Equals(Guid.Empty))
                return BadRequest();

            var item = _items.FirstOrDefault(item => item.Id.Equals(itemId));

            if(item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet("items")]
        [Produces(typeof(IReadOnlyList<ToDoItemGetDto>))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IReadOnlyList<ToDoItemGetDto>> GetToDoItems()
        {
            if (_items.Any() == false)
                return NotFound();

            return Ok(_items);
        }
    }
}
