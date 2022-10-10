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
    public class UsersController: ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "UserGet")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserGetDto>> GetUserAsync([FromQuery] Guid userId)
        {
            var user = await _usersRepository.GetAsync(userId);

            await Task.CompletedTask;

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserGetDto>(user));
        }

        [HttpPost("register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> RegisterAsync([FromBody] UserPostDto registerUser)
        {
            if (registerUser == null) throw new NullReferenceException(nameof(registerUser));

            var userExists = await _usersRepository.GetByNameAsync(registerUser.UserName);

            if (userExists != null) return BadRequest("User already exists.");

            var mapped = _mapper.Map<UserModel>(registerUser);

            await _usersRepository.AddAsync(mapped);

            return CreatedAtRoute("UserGet", mapped.Id);
        }
    }
}
