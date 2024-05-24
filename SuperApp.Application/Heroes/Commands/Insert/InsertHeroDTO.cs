namespace SuperApp.Application.Heroes.Commands.Insert;

public class InsertHeroDTO
{
    public required string Name { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Place { get; set; } = string.Empty;
    public string Power { get; set; } = string.Empty;
}