using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Mentions;
using TieMention.Application.Extensions;

namespace TieMention.Application.Mentions.Queries;

public class GetMentionQueryHandler : IRequestHandler<GetMentionQuery, MentionDetailsDto?>
{
    private readonly IMentionRepository _repository;

    public GetMentionQueryHandler(IMentionRepository repository)
    {
        _repository = repository;
    }

    public async Task<MentionDetailsDto?> Handle(GetMentionQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetMentionByIdAsync(request.Slug, cancellationToken);
    }
}
