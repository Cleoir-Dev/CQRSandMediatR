using CQRSandMediatR.Model;
using MediatR;

namespace CQRSandMediatR.Commands
{
    public class CreateCommand : IRequest<DetailModel>
    {
        public CreateCommand(bool status, string jsonContext)
        {
            Status = status;
            JsonContext = jsonContext;
        }

        public bool Status { get; set; }
        public string JsonContext { get; set; }

       
    }
}
