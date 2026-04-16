using VozniRedVlakova.Models;

namespace VozniRedVlakova.Data;

public sealed class MockRepository : IMockRepository
{
    private readonly MockDataBundle _data = MainSeedData.Create();

    private static readonly IReadOnlyList<(string Key, string Title)> _entityNavigation = new List<(string Key, string Title)>
    {
        ("vlak", "Vlakovi"),
        ("putnicki-vlak", "Putnički vlakovi"),
        ("stanica", "Stanice"),
        ("voznja", "Voznje"),
        ("putovanje", "Putovanja"),
        ("ruta", "Rute"),
        ("karta", "Karte")
    };

    public IReadOnlyList<Vlak> GetVlakovi() => _data.Vlakovi;
    public IReadOnlyList<PutnickiVlak> GetPutnickiVlakovi() => _data.PutnickiVlakovi;
    public IReadOnlyList<Stanica> GetStanice() => _data.Stanice;
    public IReadOnlyList<Voznja> GetVoznje() => _data.Voznje;
    public IReadOnlyList<Putovanje> GetPutovanja() => _data.Putovanja;
    public IReadOnlyList<Ruta> GetRute() => _data.Rute;
    public IReadOnlyList<Karta> GetKarte() => _data.Karte;
    public IReadOnlyList<ErrorViewModel> GetErrori() => _data.Errori;

    public IEnumerable<object> GetByEntity(string entityKey) => entityKey.ToLowerInvariant() switch
    {
        "vlak" => GetVlakovi(),
        "putnicki-vlak" => GetPutnickiVlakovi(),
        "stanica" => GetStanice(),
        "voznja" => GetVoznje(),
        "putovanje" => GetPutovanja(),
        "ruta" => GetRute(),
        "karta" => GetKarte(),
        _ => Enumerable.Empty<object>()
    };

    public object? GetByEntityAndId(string entityKey, int id)
    {
        return GetByEntity(entityKey).FirstOrDefault(item =>
        {
            var idProperty = item.GetType().GetProperty("Id");
            if (idProperty == null)
            {
                return false;
            }

            var value = idProperty.GetValue(item);
            return value is int itemId && itemId == id;
        });
    }

    public string GetEntityTitle(string entityKey)
    {
        var item = _entityNavigation.FirstOrDefault(x => x.Key.Equals(entityKey, StringComparison.OrdinalIgnoreCase));
        return item == default ? "Entitet" : item.Title;
    }

    public IReadOnlyList<(string Key, string Title)> GetEntityNavigation() => _entityNavigation;
}
