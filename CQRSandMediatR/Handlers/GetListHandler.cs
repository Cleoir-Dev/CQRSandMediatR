using CQRSandMediatR.Model;
using CQRSandMediatR.Queries;
using CQRSandMediatR.Repositories;
using MediatR;

namespace CQRSandMediatR.Handlers
{
    public class GetListHandler : IRequestHandler<GetListQuery, List<DetailModel>>
    {
        private readonly IContextRepository _contextRepository;

        public GetListHandler(IContextRepository contextRepository)
        {
            _contextRepository = contextRepository;
        }

        public async Task<List<DetailModel>> Handle(GetListQuery query, CancellationToken cancellationToken)
        {
            return await _contextRepository.GetListAsync();
        }
    }
}
