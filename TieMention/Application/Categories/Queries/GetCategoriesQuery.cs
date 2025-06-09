using MediatR;
using TieMention.Application.Dtos;
using TieMention.Application.Dtos.Categories;

namespace TieMention.Application.Categories.Queries;

public record GetCategoriesQuery : IRequest<List<CategoryGetDto>>;
