using FileUploadSystem.Business.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadSystem.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}