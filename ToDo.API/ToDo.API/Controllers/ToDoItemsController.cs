using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.DataAccess;
using ToDo.API.Dtos;
using ToDo.API.Models;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoItemsRepository _itemsRepository;
        private readonly IMapper _mapper;

        public ToDoItemsController(IToDoItemsRepository itemsRepository, IMapper mapper)
        {
            _itemsRepository = itemsRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetItem")]
        [Produces(typeof(ToDoItemGetDto))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ToDoItemGetDto>> GetToDoItemAsync([FromQuery]Guid userId, [FromQuery]Guid itemId)
        {
            if (itemId.Equals(Guid.Empty))
                return BadRequest();

            var item = await _itemsRepository.GetById(userId, itemId);

            if(item == null)
                return NotFound();

            return Ok(_mapper.Map<ToDoItemGetDto>(item));
        }

        [HttpGet("items")]
        [Produces(typeof(IReadOnlyList<ToDoItemGetDto>))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IReadOnlyList<ToDoItemGetDto>>> GetToDoItemsAsync([FromQuery] Guid userId)
        {
            var items = await _itemsRepository.GetAll(userId);

            if (items.Any() == false)
                return NotFound();

            return Ok(_mapper.Map<IReadOnlyCollection<ToDoItemGetDto>>(items));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateItemAsync([FromBody] ToDoItemPostDto toDoItem)
        {
            var mappedItem = _mapper.Map<ToDoItem>(toDoItem);

            await _itemsRepository.CreateItemAsync(mappedItem);

            var itemFromDb = _itemsRepository.GetById(mappedItem.UserId, mappedItem.Id);

            return CreatedAtRoute("GetItem", new {ItemId = itemFromDb.Id}, itemFromDb);
        }
    }
}
