namespace VozniRedVlakova.Models;

public sealed class EntityDetailsViewModel
{
    public string EntityKey { get; set; } = string.Empty;
    public string EntityTitle { get; set; } = string.Empty;
    public object? Item { get; set; }
}
