using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Aruk
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public int KategoriaId { get; set; }
        public string Leiras { get; set;}
        public int Keszlet { get; set;}
        public int Ar { get; set; }
        public string KepUrl { get; set;}

        public Kategoriak? Kategoria { get; set; }  //másik táblából a kategriaId által meghat. kategoria objektum

        public override string ToString()   //ez a képernyőre kiiratáshoz kell, a Program.cs-hez (konzoloshoz)
        {
            return $"Nev: {Nev}, Leiras: {Leiras}";
        }
    }
}
