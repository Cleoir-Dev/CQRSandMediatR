using MediatR;

namespace CQRSandMediatR.Commands
{
    public class DeleteCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
