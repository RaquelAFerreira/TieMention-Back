using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Dtos;

namespace TieMention.Application.Pieces.Queries;

public class GetMentionerPiecesQueryHandler : IRequestHandler<GetMentionerPiecesQuery, List<PieceGetMentionDto>>
{
    private readonly IPieceRepository _repository;

    public GetMentionerPiecesQueryHandler(IPieceRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<PieceGetMentionDto>> Handle(GetMentionerPiecesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetMentionersAsync(request.MentionedPieceId, cancellationToken);
    }
}