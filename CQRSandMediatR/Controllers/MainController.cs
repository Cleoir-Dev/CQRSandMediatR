using CQRSandMediatR.Commands;
using CQRSandMediatR.Queries;
using MediatR;
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
                jsonContext = "Json não encontrado!"
            };

            return result;

        }


        [HttpPost]
        public async Task<int> AddAsync(object json)
        {
            JsonObject obj = JsonNode.Parse(json.ToString()).AsObject();

            var id = await _mediator.Send(new CreateCommand(obj["jsonContext"].ToString()));

            return id;
        }

        [HttpPut]
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
        public async Task<int> DeleteAsync(Guid id)
        {
            return await _mediator.Send(new DeleteCommand() { Id = id });
        }

    }
}
