using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;

namespace TieMention.Application.Mentions.Commands;

public class CreateMentionCommandHandler : IRequestHandler<CreateMentionCommand, Mention>
{
    private readonly IMentionRepository _repository;

    private readonly IPieceReadModel _pieceReadModel;

    private readonly IImageRepository _imageRepository;

    public CreateMentionCommandHandler(
        IMentionRepository repository,
        IPieceReadModel pieceReadModel,
        IImageRepository imageRepository
    )
    {
        _repository = repository;
        _pieceReadModel = pieceReadModel;
        _imageRepository = imageRepository;
    }

    public async Task<Mention> Handle(
        CreateMentionCommand request,
        CancellationToken cancellationToken
    )
    {
        var mentionerSlug = await _pieceReadModel.GetSlugByIdAsync(
            request.MentionerPieceId,
            cancellationToken
        );
        var mentionedSlug = await _pieceReadModel.GetSlugByIdAsync(
            request.MentionedPieceId,
            cancellationToken
        );

        //Get the mentioner and mentioned data like slug to make the mention slug
        var mention = new Mention
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Description = request.Description,
            // IsApproved = request.IsApproved,
            MentionerPieceId = request.MentionerPieceId,
            MentionedPieceId = request.MentionedPieceId,
            Slug = mentionerSlug + "-mentions-" + mentionedSlug
        };

        await _repository.AddAsync(mention);

        var image = new Image
        {
            Id = Guid.NewGuid(),
            Description = "",
            Content = request.Image,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Order = 1,
            MentionId = mention.Id
        };

        await _imageRepository.AddAsync(image);

        await _repository.SaveChangesAsync();
        await _imageRepository.SaveChangesAsync();

        return mention;
    }
}
