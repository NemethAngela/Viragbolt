
using System.Collections.Generic;

namespace AutosKonzolApp
{
    public class Auto
    {
        // Sorszám;Márka;Modell;Gyártási év;Szín;Eladott darabszám;Átlagos eladási ár;
        public int Sorszam { get; set; }    
        public string Marka { get; set; }
        public string Modell { get; set; }
        public int GyartasiEv { get; set; }
        public string Szin { get; set; }
        public int EladottDbSzam { get; set; }
        public int AtlagosEladasiAr { get; set; }

        public string DisplayText { //Form1-ben a kilistázott dolgok vannak
            get
            {
                return Marka + " " + Modell;
            }  
        }

        public Auto(string csvSor)
        {
            string[] ertekek = csvSor.Split(";");
            Sorszam = int.Parse(ertekek[0]);
            Marka = ertekek[1];
            Modell = ertekek[2];
            GyartasiEv = int.Parse(ertekek[3]);
            Szin = ertekek[4];
            EladottDbSzam = int.Parse(ertekek[5]);
            AtlagosEladasiAr = int.Parse(ertekek[6]);
        }

        public static List<Auto> CsvtBeolvas(string csvPath)
        {
            var sorok = File.ReadAllLines(csvPath).Skip(1);
            List<Auto> autok = new List<Auto>();

            foreach (var sor in sorok) 
            {
                autok.Add(new Auto(sor));
            }

            return autok;
        }
    }
}
