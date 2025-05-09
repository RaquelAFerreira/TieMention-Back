using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Extensions;

namespace TieMention.Application.Pieces.Queries;

public class GetPieceQueryHandler : IRequestHandler<GetPieceQuery, PieceGetByIdDto?>
{
    private readonly IPieceRepository _repository;

    public GetPieceQueryHandler(IPieceRepository repository)
    {
        _repository = repository;
    }

    public async Task<PieceGetByIdDto?> Handle(GetPieceQuery request, CancellationToken cancellationToken)
    {
        var piece = await _repository.GetByIdAsync(request.Id);

        if (piece == null)
            return null;

        return piece.ToPieceGetByIdDto();
    }
}
