using MediatR;

namespace CQRSandMediatR.Commands.CategoryCommand.cs
{
    public class UpdateCategoryCommand : IRequest<int>
    {
        public UpdateCategoryCommand(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public Guid Id { get; private set; }
        public string Title { get; set; }
    }
}
