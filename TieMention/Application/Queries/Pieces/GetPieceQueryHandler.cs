using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Extensions;

namespace TieMention.Application.Pieces.Queries;

public class GetPieceQueryHandler : IRequestHandler<GetPieceQuery, PieceDetailsDto?>
{
    private readonly IPieceRepository _repository;

    public GetPieceQueryHandler(IPieceRepository repository)
    {
        _repository = repository;
    }

    public async Task<PieceDetailsDto?> Handle(GetPieceQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetDetailsByIdAsync(request.Slug, cancellationToken);
    }
}
