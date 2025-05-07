using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;

namespace TieMention.Application.Mentions.Queries;

public class GetMentionQueryHandler : IRequestHandler<GetMentionQuery, Mention?>
{
    private readonly IMentionRepository _repository;

    public GetMentionQueryHandler(IMentionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Mention?> Handle(GetMentionQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}