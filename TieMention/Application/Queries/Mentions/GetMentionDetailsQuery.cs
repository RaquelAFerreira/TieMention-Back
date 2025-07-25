using MediatR;
using TieMention.Domain.Entities;
using TieMention.Application.Dtos.Mentions;

namespace TieMention.Application.Mentions.Queries;

public record GetMentionDetailsQuery(string Slug) : IRequest<MentionDetailsDto?>;
