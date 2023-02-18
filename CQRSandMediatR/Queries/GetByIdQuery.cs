using CQRSandMediatR.Model;
using MediatR;

namespace CQRSandMediatR.Queries
{
    public class GetByIdQuery : IRequest<DetailModel>
    {
        public Guid Id { get; set; }
    }
}
