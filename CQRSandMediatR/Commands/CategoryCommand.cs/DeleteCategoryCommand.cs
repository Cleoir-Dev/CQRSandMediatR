using MediatR;

namespace CQRSandMediatR.Commands.CategoryCommand.cs
{
    public class DeleteCategoryCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
