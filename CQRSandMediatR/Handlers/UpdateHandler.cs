using CQRSandMediatR.Commands;
using CQRSandMediatR.Repositories;
using MediatR;

namespace CQRSandMediatR.Handlers
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, int>
    {
        private readonly IContextRepository _contextRepository;

        public UpdateHandler(IContextRepository contextRepository)
        {
            _contextRepository = contextRepository;
        }
        public async Task<int> Handle(UpdateCommand command, CancellationToken cancellationToken)
        {
            var detail = await _contextRepository.GetByIdAsync(command.Id);
            if (detail == null)
                return default;

            detail.Status = command.Status;
            detail.JsonContext = command.JsonContext;

            return await _contextRepository.UpdateAsync(detail);
        }
    }
}
