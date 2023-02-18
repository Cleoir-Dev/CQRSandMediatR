using CQRSandMediatR.Model;
using CQRSandMediatR.Queries;
using CQRSandMediatR.Repositories;
using MediatR;

namespace CQRSandMediatR.Handlers
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, DetailModel>
    {
        private readonly IContextRepository _contextRepository;

        public GetByIdHandler(IContextRepository contextRepository)
        {
            _contextRepository = contextRepository;
        }

        public async Task<DetailModel> Handle(GetByIdQuery query, CancellationToken cancellationToken)
        {
            return await _contextRepository.GetByIdAsync(query.Id);
        }
    }
}
