using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace f_szom_doga
{
    internal class Versenyzok
    {
        public string Nev { get; set; }
        public int SzulEv { get; set; }
        public int Rajtszam { get; set; }
        public bool Nem { get; set; }
        public string Kategoria { get; set; }
        public int UszasIdo { get; set; }
        public int Depo1 { get; set; }
        public int KerekparIdo { get; set; }
        public int Depo2 { get; set; }
        public int FutasIdo { get; set; }

        public override string ToString()
        {
            return $" {Nev} (Születési év: {SzulEv} " +
                $"Rajtszám: {Rajtszam} perc " +
                $"Nem: {Nem}" + 
                $"Kategória: {Kategoria}" + 
                $"Úszás ideje: {UszasIdo}" + 
                $"Első depó ideje: {Depo1}" + 
                $"Kerékpározás ideje: {KerekparIdo}" + 
                $"Második depóban töltött idő: {Depo2}" + 
                $"Futás ideje: {FutasIdo})";
        }

        public Versenyzok(string row)
        {
            var v = row.Split(';');
            Nev = v[0];
            SzulEv = int.Parse(v[1]);
            Rajtszam = int.Parse(v[2]);
            Nem = v[3] == "f" ? true : false; // férfi == true
            Kategoria = v[4];
            UszasIdo = ValtasMasodperc(v[5]);
            Depo1 = ValtasMasodperc(v[6]);
            KerekparIdo = ValtasMasodperc(v[7]);
            Depo2 = ValtasMasodperc(v[8]);
            FutasIdo = ValtasMasodperc(v[9]);
        }

        private int ValtasMasodperc(string time)
        {
            var v = time.Split(":");
            int ora = int.Parse(v[0]);
            int perc = int.Parse(v[1]);
            int masodperc = int.Parse(v[2]);

            return (ora * 60 * 60 + perc * 60 + masodperc);
        }

        public int Time()
        {
            int times = UszasIdo + FutasIdo + KerekparIdo + Depo1 + Depo2;
            return times;
        }
    }
}
