using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.DataAccess;
using ToDo.API.Dtos;
using ToDo.API.Models;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoItemsRepository _itemsRepository;
        private readonly IMapper _mapper;

        public ToDoItemsController(IToDoItemsRepository itemsRepository, IMapper mapper)
        {
            _itemsRepository = itemsRepository;
            _mapper = mapper;
        }

        [HttpGet("{itemId}", Name = "GetItem")]
        [Produces(typeof(ToDoItemGetDto))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ToDoItemGetDto>> GetToDoItemAsync(Guid itemId)
        {
            if (itemId.Equals(Guid.Empty))
                return BadRequest();

            var item = await _itemsRepository.GetById(itemId);

            if(item == null)
                return NotFound();

            return Ok(_mapper.Map<ToDoItemGetDto>(item));
        }

        [HttpGet("items")]
        [Produces(typeof(IReadOnlyList<ToDoItemGetDto>))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IReadOnlyList<ToDoItemGetDto>>> GetToDoItemsAsync()
        {
            var items = await _itemsRepository.GetAll();

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

            var itemFromDb = _itemsRepository.GetById(mappedItem.Id);

            return CreatedAtRoute("GetItem", new {ItemId = itemFromDb.Id}, itemFromDb);
        }
    }
}
