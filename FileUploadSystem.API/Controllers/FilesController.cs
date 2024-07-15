using FileUploadSystem.Business.Files.Commands;
using FileUploadSystem.Business.Files.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadSystem.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public class FilesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FilesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromForm] IFormFile file)
    {
        var command = new FileUploadCommand() { File = file };
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] FileEditCommand fileEditCommand)
    {
        var response = await _mediator.Send(fileEditCommand);
        return Ok(response);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deleteCommand = new FileDeleteCommand() { Id = id };
        var response = await _mediator.Send(deleteCommand);
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> List([FromQuery] ListFileQuery query )
    { 
        var response = await _mediator.Send(query);
        return Ok(response);
    }
}