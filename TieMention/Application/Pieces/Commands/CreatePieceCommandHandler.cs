using MediatR;
using Microsoft.EntityFrameworkCore;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;

namespace TieMention.Application.Pieces.Commands;

public class CreatePieceCommandHandler : IRequestHandler<CreatePieceCommand, int>
{
    private readonly IPieceRepository _repository;
    private readonly IImageRepository _imageRepository;

    public CreatePieceCommandHandler(IPieceRepository repository, IImageRepository imageRepository)
    {
        _repository = repository;
        _imageRepository = imageRepository;
    }

    public async Task<int> Handle(CreatePieceCommand request, CancellationToken cancellationToken)
    {
        string slug = Piece.GenerateSlug(request.Name, request.ReleaseYear);

        List<Guid> slugsIds = await _repository.GetIdBySlugAsync(slug, cancellationToken);

        if (slugsIds.Count() != 0)
            slug = $"{slug}-{slugsIds.Count()}";

        var piece = Piece.Create(
            request.Name,
            request.Description,
            request.Category,
            request.ReleaseYear,
            slug
        );

        var image = Image.Create(
            request.Image,
            piece.Id,
            new Guid(),
            description: "",
            order: 1
        );

        // Add transaction security later
        try
        {
            await _repository.AddAsync(piece);
            await _imageRepository.AddAsync(image);
            await _repository.SaveChangesAsync();
            await _imageRepository.SaveChangesAsync();

            return 0;
        }
        catch
        {
            return 1;
        }
    }
}
