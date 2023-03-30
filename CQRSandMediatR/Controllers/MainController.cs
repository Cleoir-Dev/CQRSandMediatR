using CQRSandMediatR.Commands;
using CQRSandMediatR.Models;
using CQRSandMediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace CQRSandMediatR.Controllers
{
    [ApiController]
    [Route("api/main")]
    public class MainController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<object>> GetListAsync()
        {
            List<object> ResultList = new List<object>();

            var details = await _mediator.Send(new GetListQuery());

            foreach (var detail in details)
            {
                ResultList.Add(new
                {
                    id = detail.Id,
                    status = detail.Status,
                    jsonContext = JsonNode.Parse(detail.JsonContext).AsObject()
                });
            }

            return ResultList;
        }

        [HttpGet("id")]
        [Authorize]
        public async Task<object> GetByIdAsync(Guid id)
        {
            object? result;

            var detail = await _mediator.Send(new GetByIdQuery() { Id = id });

            if (detail != null)
            {
                result = new
                {
                    id = detail.Id,
                    status = detail.Status,
                    jsonContext = JsonNode.Parse(detail.JsonContext).AsObject()
                };
                return result;
            }

            result = new
            {
                id = id,
                status = false,
                jsonContext = "Json not find!"
            };

            return result;

        }


        [HttpPost]
        [Authorize(Roles = UserRoles.User)]
        public async Task<int> AddAsync(object json)
        {
            JsonObject obj = JsonNode.Parse(json.ToString()).AsObject();

            var id = await _mediator.Send(new CreateCommand(obj["jsonContext"].ToString()));

            return id;
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<int> UpdateAsync(object json)
        {

            JsonObject obj = JsonNode.Parse(json.ToString()).AsObject();

            var id = await _mediator.Send(new UpdateCommand(
                (Guid)obj["id"],
                (bool)obj["status"],
                obj["jsonContext"].ToString()));

            return id;

        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<int> DeleteAsync(Guid id)
        {
            return await _mediator.Send(new DeleteCommand() { Id = id });
        }

    }
}
