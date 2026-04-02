using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozniRedVlakova.Models
{
    public class Vlak
    {
        public string? Naziv { get; set; }
        public int MaxBrzina { get; set; }
        public int MjestaPoVagonu { get; set; }
    }
    public enum Znacajka
    {
        Rezervacija,
        ZaInvalide,
        ZaBicikle,
        WC,
        Lezaj
    }
    public class PutnickiVlak : Vlak
    {
        public int Broj { get; set; }
        public int Vagoni { get; set; }
        public HashSet<Znacajka>? Znacajke { get; set; }
        public bool Brzi { get; set; }
    }
    public enum VrstaStanice
    {
        Kolodvor,
        Postaja,
        Stajaliste
    }
    public class Stanica
    {
        public string? Naziv { get; set; }
        public bool StajeBrzi { get; set; }
        public string? Grad { get; set; }
        public string? Adresa { get; set; }
        public bool ProdajaKarte { get; set; }
        public VrstaStanice? Vrsta { get; set; }
    }
    public class Putovanje
    {
        public List<Voznja> Voznje { get; set; }
        public Putovanje()
        {
            Voznje = new List<Voznja>();
            _ = Voznje.OrderBy(i => i.Odlazak);
        }
        public double Trajanje()
        {
            //return Voznje.Sum(v => v.Trajanje());
            return (Voznje.Last().Dolazak - Voznje.First().Odlazak).TotalMinutes;
        }
        public int BrojVoznji()
        {
            return Voznje.Count();
        }
    }
    public class Ruta
    {
        public List<Stanica> Stanice { get; set; }
        public Ruta()
        {
            Stanice = new List<Stanica>();
        }
        public bool ImaStanicu(Stanica stanica)
        {
            return Stanice.Any(s => s.Equals(stanica));
        }
    }
    public class Voznja
    {
        public PutnickiVlak? Vlak { get; set; }
        public DateTime Odlazak { get; set; }
        public Stanica? StanicaOdlaska { get; set; }
        public DateTime Dolazak { get; set; }
        public Stanica? StanicaDolaska { get; set; }
        public double Kasni { get; set; }
        public double Trajanje()
        {
            return (Dolazak - Odlazak).TotalMinutes;
        }
    }
    public class Karta
    {
        public int BrojPutnika { get; set; }
        public Putovanje? Putovanje { get; set; }
        public Putovanje? Povratno { get; set; }
        public decimal CijenaPoVoznji { get; set; }
        public bool Popust { get; set; }
        public int? BrojMjesta { get; set; }
        public decimal Cijena()
        {
            var voznje = Putovanje.BrojVoznji();
            if (Povratno != null) voznje += Povratno.BrojVoznji();
            return ((voznje * CijenaPoVoznji) / (Popust ? 2 : 1)) * BrojPutnika;
        }
    }
}
