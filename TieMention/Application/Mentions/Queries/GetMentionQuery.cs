using MediatR;
using TieMention.Domain.Entities;

namespace TieMention.Application.Mentions.Queries;
public record GetMentionQuery(int Id) : IRequest<Mention?>;