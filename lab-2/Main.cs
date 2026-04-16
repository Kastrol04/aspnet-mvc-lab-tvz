using VozniRedVlakova.Models;

namespace VozniRedVlakova.Data;

public sealed class MockDataBundle
{
    public List<Vlak> Vlakovi { get; init; } = new();
    public List<PutnickiVlak> PutnickiVlakovi { get; init; } = new();
    public List<Stanica> Stanice { get; init; } = new();
    public List<Voznja> Voznje { get; init; } = new();
    public List<Putovanje> Putovanja { get; init; } = new();
    public List<Ruta> Rute { get; init; } = new();
    public List<Karta> Karte { get; init; } = new();
    public List<ErrorViewModel> Errori { get; init; } = new();
}

public static class MainSeedData
{
    public static MockDataBundle Create()
    {
        // Podaci temeljeni na originalnom Main.cs primjeru (vlakovi, stanice, voznje)
        // i prošireni za sve entitete potrebne za prikaz.

        var putnickiVlakovi = new List<PutnickiVlak>
        {
            new()
            {
                Id = 1,
                Naziv = "InterCity 520",
                MaxBrzina = 160,
                MjestaPoVagonu = 60,
                Broj = 520,
                Vagoni = 6,
                Brzi = true,
                Znacajke = new HashSet<Znacajka> { Znacajka.Rezervacija, Znacajka.WC, Znacajka.ZaBicikle }
            },
            new()
            {
                Id = 2,
                Naziv = "Regional 701",
                MaxBrzina = 120,
                MjestaPoVagonu = 52,
                Broj = 701,
                Vagoni = 4,
                Brzi = false,
                Znacajke = new HashSet<Znacajka> { Znacajka.WC, Znacajka.ZaInvalide }
            },
            new()
            {
                Id = 3,
                Naziv = "Express 903",
                MaxBrzina = 200,
                MjestaPoVagonu = 58,
                Broj = 903,
                Vagoni = 7,
                Brzi = true,
                Znacajke = new HashSet<Znacajka> { Znacajka.Rezervacija, Znacajka.WC, Znacajka.Lezaj }
            }
        };

        var stanice = new List<Stanica>
        {
            new() { Id = 1, Naziv = "Zagreb Glavni", Grad = "Zagreb", Adresa = "Trg kralja Tomislava 12", StajeBrzi = true, ProdajaKarte = true, Vrsta = VrstaStanice.Kolodvor },
            new() { Id = 2, Naziv = "Karlovac", Grad = "Karlovac", Adresa = "Kolodvorska 5", StajeBrzi = true, ProdajaKarte = true, Vrsta = VrstaStanice.Postaja },
            new() { Id = 3, Naziv = "Rijeka", Grad = "Rijeka", Adresa = "Žabica 1", StajeBrzi = true, ProdajaKarte = true, Vrsta = VrstaStanice.Kolodvor },
            new() { Id = 4, Naziv = "Lekenik", Grad = "Lekenik", Adresa = "Stajalište 2", StajeBrzi = false, ProdajaKarte = false, Vrsta = VrstaStanice.Stajaliste }
        };

        var voznje = new List<Voznja>
        {
            new()
            {
                Id = 1,
                Vlak = putnickiVlakovi[0],
                StanicaOdlaska = stanice[0],
                StanicaDolaska = stanice[2],
                Odlazak = DateTime.Today.AddHours(7),
                Dolazak = DateTime.Today.AddHours(10),
                Kasni = 0
            },
            new()
            {
                Id = 2,
                Vlak = putnickiVlakovi[1],
                StanicaOdlaska = stanice[0],
                StanicaDolaska = stanice[1],
                Odlazak = DateTime.Today.AddHours(9),
                Dolazak = DateTime.Today.AddHours(10.5),
                Kasni = 5
            },
            new()
            {
                Id = 3,
                Vlak = putnickiVlakovi[2],
                StanicaOdlaska = stanice[1],
                StanicaDolaska = stanice[2],
                Odlazak = DateTime.Today.AddHours(13),
                Dolazak = DateTime.Today.AddHours(15),
                Kasni = 0
            }
        };

        var putovanja = new List<Putovanje>
        {
            new() { Id = 1, Voznje = new List<Voznja> { voznje[0] } },
            new() { Id = 2, Voznje = new List<Voznja> { voznje[1], voznje[2] } }
        };

        var rute = new List<Ruta>
        {
            new() { Id = 1, Stanice = new List<Stanica> { stanice[0], stanice[1], stanice[2] } },
            new() { Id = 2, Stanice = new List<Stanica> { stanice[0], stanice[3] } }
        };

        var karte = new List<Karta>
        {
            new() { Id = 1, BrojPutnika = 1, Putovanje = putovanja[0], Povratno = null, CijenaPoVoznji = 19.50m, Popust = false, BrojMjesta = 12 },
            new() { Id = 2, BrojPutnika = 2, Putovanje = putovanja[1], Povratno = putovanja[0], CijenaPoVoznji = 14.90m, Popust = true, BrojMjesta = 22 }
        };

        var vlakovi = putnickiVlakovi.Cast<Vlak>().ToList();

        var errori = new List<ErrorViewModel>
        {
            new() { Id = 1, RequestId = "REQ-2026-0001" },
            new() { Id = 2, RequestId = "REQ-2026-0002" }
        };

        return new MockDataBundle
        {
            Vlakovi = vlakovi,
            PutnickiVlakovi = putnickiVlakovi,
            Stanice = stanice,
            Voznje = voznje,
            Putovanja = putovanja,
            Rute = rute,
            Karte = karte,
            Errori = errori
        };
    }
}
