using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Mentions;
using TieMention.Application.Extensions;

namespace TieMention.Application.Mentions.Queries;

public class GetMentionQueryHandler : IRequestHandler<GetMentionQuery, MentionGetDto?>
{
    private readonly IMentionRepository _repository;

    public GetMentionQueryHandler(IMentionRepository repository)
    {
        _repository = repository;
    }

    public async Task<MentionGetDto?> Handle(GetMentionQuery request, CancellationToken cancellationToken)
    {
        var mention = await _repository.GetByIdAsync(request.Id);
        
        if (mention == null)
            return null;

        return mention?.ToMentionGetDto();
    }
}
