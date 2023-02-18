using CQRSandMediatR.Commands;
using CQRSandMediatR.Model;
using CQRSandMediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSandMediatR.Controllers
{
    [ApiController]
    [Route("api/main")]
    public class MainController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MainController> _logger;

        public MainController(IMediator mediator, ILogger<MainController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<DetailModel>> GetListAsync()
        {
            var details = await _mediator.Send(new GetListQuery());

            return details;
        }

        [HttpGet("id")]
        public async Task<DetailModel> GetByIdAsync(Guid id)
        {
            var details = await _mediator.Send(new GetByIdQuery() { Id = id });

            return details;
        }


        [HttpPost]
        public async Task<DetailModel> AddAsync(DetailModel details)
        {
            var result = await _mediator.Send(new CreateCommand(
                details.Status,
                details.JsonContext));
            return result;
        }

        [HttpPut]
        public async Task<int> UpdateAsync(DetailModel details)
        {
            var id = await _mediator.Send(new UpdateCommand(
               details.Id,
                details.Status,
               details.JsonContext));
            return id;
        }

        [HttpDelete]
        public async Task<int> DeleteAsync(Guid id)
        {
            return await _mediator.Send(new DeleteCommand() { Id = id });
        }

    }
}
