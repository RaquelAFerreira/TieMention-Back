using TieMention.Domain.Entities;
using TieMention.Application.Dtos.Pieces;
using TieMention.Application.Dtos;

namespace TieMention.Domain.Interfaces;

public interface IPieceReadModel
{
    Task<PieceDetailsDto?> GetDetailsByIdAsync(string slug, CancellationToken cancellationToken);

    Task<PaginatedResult<PieceDetailsDto>> GetPagedAsync(string? name, int page, int pageSize, CancellationToken cancellationToken);

    Task<List<PieceGetMentionDto>> GetMentionersAsync(Guid mentionedPieceId, CancellationToken cancellationToken);

    Task<string?> GetSlugByIdAsync(Guid pieceId, CancellationToken cancellationToken);

    Task<List<Guid>> GetIdBySlugAsync(string slug, CancellationToken cancellationToken);

    Task<List<PieceNameDto?>> GetPieceByNameAsync(string Name, CancellationToken cancellationToken);
}
