using MediatR;

namespace CQRSandMediatR.Commands
{
    public class UpdateCommand : IRequest<int>
    {
        public UpdateCommand(Guid id, bool status, string jsonContext)
        {
            Id = id;
            Status = status;
            JsonContext = jsonContext;
        }

        public Guid Id { get; private set; }
        public bool Status { get; set; }
        public string JsonContext { get; set; }
    }
}
