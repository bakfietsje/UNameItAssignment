using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UNameItAssignment.Commands;
using UNameItAssignment.DTOs;
using UNameItAssignment.Requests;

namespace UNameItAssignment.Controllers;

[Route("api/[controller]")]
public class WordCloudController(IMediator mediator) : ControllerBase
{
    [HttpPost("word-count")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IEnumerable<WordCountDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetWordCount(
        [FromBody] GetWordCountRequest request,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var command = new CountWordsCommand(request.Text, cancellationToken);
        
        var result = await mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}