using System.Text;

namespace f_szom_doga
{
    internal class Program
    {
        public static List<Versenyzok> versenyzok = [];
        static void Main(string[] args)
        {
            using StreamReader sr = new(
                path: "forras.txt",
                encoding: Encoding.UTF8);

            while (!sr.EndOfStream) versenyzok.Add(new(sr.ReadLine()));
            Console.WriteLine($"{versenyzok.Count} versenyző vett részt.");

            Elit();
            NoKor();
            OsszKerekpar();
            AtlagUszas();
            FerfiGyoztes();
            KategoriaBefejez();

        }

        private static void Elit()
        {
            var elit = versenyzok.FindAll(x => x.Kategoria == "elit").Count;
            Console.WriteLine($"Ennyi versenyző van elit kategóriában: {elit}");
        }

        private static void NoKor()
        {
            var noKor = versenyzok.Where(x => x.Nem == false).Average(x => 2024 - x.SzulEv);
            Console.WriteLine($"A nők átlag életkora: {noKor}");
        }

        private static void OsszKerekpar()
        {
            float ido = versenyzok.Sum(x => x.KerekparIdo);
            ido = ido / 60 / 60;
            Console.WriteLine($"A kerékpározással töltött idő: {Math.Round(ido, 2)} óra");
        }

        private static void AtlagUszas()
        {
            var ido = versenyzok.Where(x => x.Kategoria == "elit junior").Average(x => x.UszasIdo);
            Console.WriteLine($"Az össz úszás idő elit juniorban idő: {ido / 60} perc");
        }

        private static void FerfiGyoztes()
        {
            var gyoztes = versenyzok.Where(x => x.Nem == true).Min(x => x.Time());
            Console.WriteLine($"A férfi győztes: {gyoztes}");
        }

        private static void KategoriaBefejez()
        {
            string[] kategoriak = new string[]
            {
                "16 - 17",
                "18 - 19",
                "20 - 24",
                "25 - 29",
                "30 - 34",
                "35 - 39",
                "40 - 44",
                "45 - 49",
                "50 - 54",
                "elit",
                "elit junior"
            };

            for (int i = 0; i < kategoriak.Length; i++)
            {
                var ossz = versenyzok.FindAll(x => x.Kategoria == kategoriak[i]).Count;
                Console.WriteLine($"{kategoriak[i]} kategória versenyszők száma: {ossz}");
            }
        }

        private static void KategoriaDepo()
        {

        }
    }
}
