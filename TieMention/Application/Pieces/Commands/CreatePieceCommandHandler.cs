using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;

namespace TieMention.Application.Pieces.Commands;

public class CreatePieceCommandHandler : IRequestHandler<CreatePieceCommand, Piece>
{
    private readonly IPieceRepository _repository;

    public CreatePieceCommandHandler(IPieceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Piece> Handle(CreatePieceCommand request, CancellationToken cancellationToken)
    {
        var piece = new Piece
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            Name = request.Name,
            Category = request.Category,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            ReleaseYear = request.ReleaseYear
        };

        await _repository.AddAsync(piece);
        await _repository.SaveChangesAsync();

        return piece;
    }
}