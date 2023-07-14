using MediatR;

namespace CQRSandMediatR.Commands.CategoryCommand.cs
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public CreateCategoryCommand(string title)
        {
            Title = title;
        }
        public string Title { get; set; }
    }
}
