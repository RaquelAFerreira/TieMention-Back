using MediatR;
using TieMention.Application.Dtos;
using TieMention.Application.Dtos.Pieces;

namespace TieMention.Application.Pieces.Queries;

public record GetPiecesQuery(string? Name, int Page, int PageSize) : IRequest<PaginatedResult<PieceGetByIdDto>>;
