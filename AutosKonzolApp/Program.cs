
using AutosKonzolApp;
using System.Linq;

List<Auto> autok = new List<Auto>();

autok = Auto.CsvtBeolvas(@"..\..\..\autok.csv");

Console.WriteLine($"5. feladat: {autok.Count} autó található a listában");

Console.WriteLine($"6. feladat: Az autók esetében az átlagosan eladott darabszám {autok.Average(a => a.EladottDbSzam):0.0}");

Console.WriteLine($"7. feladat: Az elmúlt 5 évben gyártott autók:");
var max5EvesAutok = autok.Where(a => a.GyartasiEv >= (DateTime.Now.Year - 5));
foreach (Auto auto in max5EvesAutok)
{
    Console.WriteLine($"    - {auto.Marka} {auto.Modell}: {auto.GyartasiEv}");
}

Console.WriteLine($"8. feladat: Legsikeresebb márkák listája az eladott darabszám alapján:");
foreach (Auto auto in autok)
{
    Console.WriteLine($"    - {auto.Marka}: {auto.EladottDbSzam} darab");
}