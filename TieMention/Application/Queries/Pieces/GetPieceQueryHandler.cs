using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Extensions;

namespace TieMention.Application.Pieces.Queries;

public class GetPieceQueryHandler : IRequestHandler<GetPieceQuery, PieceDetailsDto?>
{
    private readonly IPieceReadModel _readModel;

    public GetPieceQueryHandler(IPieceReadModel readModel)
    {
        _readModel = readModel;
    }

    public async Task<PieceDetailsDto?> Handle(GetPieceQuery request, CancellationToken cancellationToken)
    {
        return await _readModel.GetDetailsByIdAsync(request.Slug, cancellationToken);
    }
}
