using MediatR;
using TieMention.Application.Dtos;
using TieMention.Application.Dtos.Pieces;

namespace TieMention.Application.Pieces.Queries;

public record GetMentionerPiecesQuery(Guid MentionedPieceId) : IRequest<List<PieceGetMentionDto>>;
