using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Dtos;

namespace TieMention.Application.Pieces.Queries;

public class GetMentionerPiecesQueryHandler : IRequestHandler<GetMentionerPiecesQuery, List<PieceGetMentionDto>>
{
    private readonly IPieceReadModel _readModel;

    public GetMentionerPiecesQueryHandler(IPieceReadModel readModel)
    {
        _readModel = readModel;
    }

    public async Task<List<PieceGetMentionDto>> Handle(GetMentionerPiecesQuery request, CancellationToken cancellationToken)
    {
        return await _readModel.GetMentionersAsync(request.MentionedPieceId, cancellationToken);
    }
}
