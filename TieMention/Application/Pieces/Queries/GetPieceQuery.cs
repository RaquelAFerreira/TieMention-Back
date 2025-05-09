using MediatR;
using TieMention.Domain.Entities;
using TieMention.Application.Dtos.Pieces;

namespace TieMention.Application.Pieces.Queries;

public record GetPieceQuery(Guid Id) : IRequest<PieceGetByIdDto?>;
