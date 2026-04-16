namespace VozniRedVlakova.Models;

public sealed class EntityIndexViewModel
{
    public string EntityKey { get; set; } = string.Empty;
    public string EntityTitle { get; set; } = string.Empty;
    public List<object> Items { get; set; } = new();
}
