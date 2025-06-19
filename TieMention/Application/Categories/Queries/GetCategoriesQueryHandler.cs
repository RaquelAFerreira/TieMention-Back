using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Categories;
using TieMention.Application.Dtos;

namespace TieMention.Application.Categories.Queries;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDetailsDto>>
{
    private readonly ICategoryRepository _repository;

    public GetCategoriesQueryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CategoryDetailsDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllCategoriesAsync(cancellationToken);
    }
}