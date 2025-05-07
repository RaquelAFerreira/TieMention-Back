namespace TieMention.Domain.Entities;

public class Mention
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
}