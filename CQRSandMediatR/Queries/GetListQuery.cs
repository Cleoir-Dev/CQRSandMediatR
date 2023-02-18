using CQRSandMediatR.Model;
using MediatR;

namespace CQRSandMediatR.Queries
{
    public class GetListQuery : IRequest<List<DetailModel>>
    {
    }
}
