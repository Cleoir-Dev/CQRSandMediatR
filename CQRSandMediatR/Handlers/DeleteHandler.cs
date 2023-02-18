using CQRSandMediatR.Commands;
using CQRSandMediatR.Repositories;
using MediatR;

namespace CQRSandMediatR.Handlers
{
    public class DeleteHandler : IRequestHandler<DeleteCommand, int>
    {
        private readonly IContextRepository _contextRepository;

        public DeleteHandler(IContextRepository contextRepository)
        {
            _contextRepository = contextRepository;
        }

        public async Task<int> Handle(DeleteCommand command, CancellationToken cancellationToken)
        {
            var detail = await _contextRepository.GetByIdAsync(command.Id);
            if (detail == null)
                return default;

            return await _contextRepository.DeleteAsync(detail.Id);
        }
    }
}
