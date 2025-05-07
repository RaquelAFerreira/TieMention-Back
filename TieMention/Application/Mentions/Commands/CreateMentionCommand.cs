using MediatR;
using TieMention.Domain.Entities;

namespace TieMention.Application.Mentions.Commands;

public record CreateMentionCommand(string Name) : IRequest<Mention>;