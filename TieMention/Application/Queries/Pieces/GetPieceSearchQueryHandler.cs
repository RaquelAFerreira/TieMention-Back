using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Extensions;

namespace TieMention.Application.Pieces.Queries;

public class GetPieceSearchQueryHandler : IRequestHandler<GetPieceSearchQuery, List<PieceNameDto?>>
{
    private readonly IPieceReadModel _readModel;

    public GetPieceSearchQueryHandler(IPieceReadModel readModel)
    {
        _readModel = readModel;
    }

    public async Task<List<PieceNameDto?>> Handle(GetPieceSearchQuery request, CancellationToken cancellationToken)
    {
        return await _readModel.GetPieceByNameAsync(request.Name, cancellationToken);
    }
}
