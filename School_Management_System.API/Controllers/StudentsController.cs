using MediatR;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.Core.Features.Students.Commands.Models;
using School_Management_System.Core.Features.Students.Queries.Models;
using School_Management_System.Core.Responses;
using System.Net;

namespace School_Management_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new StudentsListQuery());
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            BaseResponse response = await _mediator.Send(new StudentByIdQuery(id));
            if (response.StatusCode == HttpStatusCode.OK)
                return Ok(response);

            return NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddStudentCommand studentCommand)
        {
            var result = await _mediator.Send(studentCommand);
            if (result.StatusCode != HttpStatusCode.Created)
                return ProcessError(result);
            return CreatedAtAction(nameof(Create), result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentCommand studentCommand)
        {
            if (id != studentCommand.Id)
                return BadRequest();

            var response = await _mediator.Send(studentCommand);
            if (response.StatusCode != HttpStatusCode.NoContent)
                return ProcessError(response);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(id));
            if (response.StatusCode != HttpStatusCode.NoContent)
                return ProcessError(response);

            return NoContent();
        }

        private IActionResult ProcessError(BaseResponse baseResponse)
        {
            switch (baseResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return NotFound((NotFoundResponse)baseResponse);
                case HttpStatusCode.BadRequest:
                    return BadRequest((BadRequestResponse)baseResponse);
                case HttpStatusCode.InternalServerError:
                    return StatusCode((int)baseResponse.StatusCode, (InternalServerErrorResponse)baseResponse);
                case HttpStatusCode.Unauthorized:
                    return Unauthorized((UnauthorizedResponse)baseResponse);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
