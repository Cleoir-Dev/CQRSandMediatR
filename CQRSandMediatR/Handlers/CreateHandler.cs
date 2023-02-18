using MediatR;
using CQRSandMediatR.Model;
using CQRSandMediatR.Commands;
using CQRSandMediatR.Repositories;

namespace CQRSandMediatR.Handlers
{
    public class CreateHandler : IRequestHandler<CreateCommand, DetailModel>
    {
        private readonly IContextRepository _contextRepository;

        public CreateHandler(IContextRepository contextRepository)
        {
            _contextRepository = contextRepository;
        }

        public async Task<DetailModel> Handle(CreateCommand command, CancellationToken cancellationToken)
        {
            var detail = new DetailModel(command.Status, command.JsonContext);
            return await _contextRepository.AddAsync(detail);
        }
    }
}
