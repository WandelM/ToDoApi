using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.DataAccess;
using ToDo.API.Dtos;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController: ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserGetDto>> GetUserAsync([FromQuery] Guid userId)
        {
            var user = _usersRepository.Get(userId);

            await Task.CompletedTask;

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserGetDto>(user));
        }
    }
}
