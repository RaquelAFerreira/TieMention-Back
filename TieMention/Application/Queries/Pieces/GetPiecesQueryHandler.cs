using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Dtos;

namespace TieMention.Application.Pieces.Queries;

public class GetPiecesQueryHandler : IRequestHandler<GetPiecesQuery, PaginatedResult<PieceDetailsDto>>
{
    private readonly IPieceReadModel _readModel;

    public GetPiecesQueryHandler(IPieceReadModel readModel)
    {
        _readModel = readModel;
    }

    public async Task<PaginatedResult<PieceDetailsDto>> Handle(GetPiecesQuery request, CancellationToken cancellationToken)
    {
        return await _readModel.GetPagedAsync(request.Name, request.Page, request.PageSize, cancellationToken);
    }
}