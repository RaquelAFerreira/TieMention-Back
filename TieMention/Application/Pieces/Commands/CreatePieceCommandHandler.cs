using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;

namespace TieMention.Application.Pieces.Commands;

public class CreatePieceCommandHandler : IRequestHandler<CreatePieceCommand, Piece>
{
    private readonly IPieceRepository _repository;
    private readonly IImageRepository _imageRepository;

    // public CreatePieceCommandHandler(IPieceRepository repository)
    // {
    //     _repository = repository;
    // }

    public CreatePieceCommandHandler(IPieceRepository repository, IImageRepository imageRepository)
    {
        _repository = repository;
        _imageRepository = imageRepository;
    }

    public async Task<Piece> Handle(CreatePieceCommand request, CancellationToken cancellationToken)
    {
        //Verify if there is another slug with the same name before

        var piece = new Piece
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            Name = request.Name,
            Category = request.Category,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            ReleaseYear = request.ReleaseYear,
            Slug = request.Name.ToSlug() + "-" + request.ReleaseYear
        };

        await _repository.AddAsync(piece);

        var image = new Image
        {
            Id = Guid.NewGuid(),
            Description = "",
            Content = request.Image,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Order = 1,
            PieceId = piece.Id
        };

        await _imageRepository.AddAsync(image);

        await _repository.SaveChangesAsync();
        await _imageRepository.SaveChangesAsync();

        return piece;
    }
}