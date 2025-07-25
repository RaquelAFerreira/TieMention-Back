using TieMention.Domain.Entities;
using TieMention.Application.Dtos.Mentions;


namespace TieMention.Domain.Interfaces;

public interface IMentionReadModel
{
    Task<MentionDetailsDto?> GetMentionByIdAsync(string Slug, CancellationToken cancellationToken);
}
