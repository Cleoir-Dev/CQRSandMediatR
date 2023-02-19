using CQRSandMediatR.Commands;
using CQRSandMediatR.Model;
using CQRSandMediatR.Repositories;
using MediatR;

namespace CQRSandMediatR.Handlers
{
    public class CreateHandler : IRequestHandler<CreateCommand, int>
    {
        private readonly IContextRepository _contextRepository;

        public CreateHandler(IContextRepository contextRepository)
        {
            _contextRepository = contextRepository;
        }

        public async Task<int> Handle(CreateCommand command, CancellationToken cancellationToken)
        {
            var detail = new DetailModel(command.JsonContext);
            return await _contextRepository.AddAsync(detail);
        }
    }
}
