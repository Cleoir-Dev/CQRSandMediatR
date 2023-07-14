using CQRSandMediatR.Models;
using MediatR;

namespace CQRSandMediatR.Queries.CategoryQuery
{
    public class GetListCategoryQuery : IRequest<List<CategoryModel>>
    {
    }
}
