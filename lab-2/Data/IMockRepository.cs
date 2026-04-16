using VozniRedVlakova.Models;

namespace VozniRedVlakova.Data;

public interface IMockRepository
{
    IReadOnlyList<Vlak> GetVlakovi();
    IReadOnlyList<PutnickiVlak> GetPutnickiVlakovi();
    IReadOnlyList<Stanica> GetStanice();
    IReadOnlyList<Voznja> GetVoznje();
    IReadOnlyList<Putovanje> GetPutovanja();
    IReadOnlyList<Ruta> GetRute();
    IReadOnlyList<Karta> GetKarte();
    IReadOnlyList<ErrorViewModel> GetErrori();

    object? GetByEntityAndId(string entityKey, int id);
    IEnumerable<object> GetByEntity(string entityKey);
    string GetEntityTitle(string entityKey);
    IReadOnlyList<(string Key, string Title)> GetEntityNavigation();
}
