using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Dtos;

namespace TieMention.Application.Pieces.Queries;

public class GetPiecesQueryHandler : IRequestHandler<GetPiecesQuery, PaginatedResult<PieceGetByIdDto>>
{
    private readonly IPieceRepository _repository;

    public GetPiecesQueryHandler(IPieceRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaginatedResult<PieceGetByIdDto>> Handle(GetPiecesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetPagedAsync(request.Name, request.Page, request.PageSize, cancellationToken);
    }
}