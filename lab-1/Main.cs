using VozniRedVlakova.Models;

List<PutnickiVlak> vlakovi = new List<PutnickiVlak>()
{
    new PutnickiVlak(), new PutnickiVlak(), new PutnickiVlak()
};
vlakovi[0].Broj = 1; vlakovi[1].Broj = 2; vlakovi[2].Broj= 3;

List<Stanica> stanice = new List<Stanica>()
{
    new Stanica(), new Stanica(), new Stanica()
};
stanice[0].Naziv = "A"; stanice[1].Naziv="B"; stanice[2].Naziv="C";

List<Voznja> voznje = new List<Voznja>()
{
    new Voznja(), new Voznja(), new Voznja()
};
voznje[0].Vlak = vlakovi[0]; voznje[1].Vlak = vlakovi[1]; voznje[2].Vlak = vlakovi[2];
voznje[0].StanicaOdlaska = stanice[0]; voznje[0].StanicaDolaska = stanice[2];
voznje[1].StanicaOdlaska = stanice[0]; voznje[1].StanicaDolaska = stanice[1];
voznje[2].StanicaOdlaska = stanice[1]; voznje[2].StanicaDolaska = stanice[2];