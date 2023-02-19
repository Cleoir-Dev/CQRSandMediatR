using MediatR;

namespace CQRSandMediatR.Commands
{
    public class CreateCommand : IRequest<int>
    {
        public CreateCommand(string jsonContext)
        {
            JsonContext = jsonContext;
        }

        public bool Status { get; set; }
        public string JsonContext { get; set; }


    }
}
