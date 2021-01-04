using Confitec.Application.Users.Commands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Confitec.Application.Users.Queries;

namespace Confitec.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : Controller
    {
        private readonly ISender _mediator;

        public UsersController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);

            if (users == null) { NotFound(); }

            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);

            if (user == null) { NotFound(); }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            if(createUserCommand == null) { return BadRequest(); }

            var user = await _mediator.Send(createUserCommand);

            return Created($"/{user.Id}", user);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserCommand updateUserCommand)
        {
            if (updateUserCommand == null) { return BadRequest(); }

            var userId = await _mediator.Send(updateUserCommand);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var deleteUserCommand = new DeleteUserCommand(id);
            var user = await _mediator.Send(deleteUserCommand);

            return NoContent();
        }
    }
}
