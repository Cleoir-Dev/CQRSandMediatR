using CQRSandMediatR.Models;
using MediatR;

namespace CQRSandMediatR.Queries.CategoryQuery
{
    public class GetByIdCategoryQuery : IRequest<CategoryModel>
    {
        public Guid Id { get; set; }
    }
}
