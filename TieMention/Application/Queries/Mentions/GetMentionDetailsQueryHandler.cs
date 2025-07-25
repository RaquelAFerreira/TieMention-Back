using MediatR;
using TieMention.Domain.Entities;
using TieMention.Domain.Interfaces;
using TieMention.Application.Dtos.Mentions;
using TieMention.Application.Extensions;

namespace TieMention.Application.Mentions.Queries;

public class GetMentionDetailsQueryHandler : IRequestHandler<GetMentionDetailsQuery, MentionDetailsDto?>
{
    private readonly IMentionReadModel _readModel;

    public GetMentionDetailsQueryHandler(IMentionReadModel readModel)
    {
        _readModel = readModel;
    }

    public async Task<MentionDetailsDto?> Handle(GetMentionDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _readModel.GetMentionByIdAsync(request.Slug, cancellationToken);
    }
}
