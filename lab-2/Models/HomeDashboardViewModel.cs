namespace VozniRedVlakova.Models;

public sealed class HomeDashboardViewModel
{
    public int UkupnoVlakova { get; set; }
    public int UkupnoStanica { get; set; }
    public int UkupnoVoznji { get; set; }
    public int UkupnoKarata { get; set; }
    public IReadOnlyList<(string Key, string Title)> Navigacija { get; set; } = new List<(string Key, string Title)>();
}
