namespace CQRSandMediatR.Models
{
    public class CategoryModel
    {
        public CategoryModel(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
