namespace Capstone.Infrastructure.Authentication;

public class DatabaseSettings
{
    public const string SectionName = "ConnectionStrings";
    public string DefaultConnection { get; init; } = string.Empty;
}