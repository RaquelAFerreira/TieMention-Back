using MediatR;
using TieMention.Domain.Entities;
using TieMention.Application.Dtos.Mentions;

namespace TieMention.Application.Mentions.Queries;

public record GetMentionQuery(String Slug) : IRequest<MentionDetailsDto?>;
