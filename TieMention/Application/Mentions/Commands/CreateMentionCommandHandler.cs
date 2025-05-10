using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;

namespace TieMention.Application.Mentions.Commands;

public class CreateMentionCommandHandler : IRequestHandler<CreateMentionCommand, Mention>
{
    private readonly IMentionRepository _repository;

    public CreateMentionCommandHandler(IMentionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Mention> Handle(CreateMentionCommand request, CancellationToken cancellationToken)
    {
        var mention = new Mention
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Description = request.Description,
            IsApproved = request.IsApproved,
            MentioningPiece = request.MentioningPiece,
            MentionedPiece = request.MentionedPiece
        };

        await _repository.AddAsync(mention);
        await _repository.SaveChangesAsync();

        return mention;
    }
}