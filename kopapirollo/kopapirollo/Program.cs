using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kopapirollo {

	class Alakzat {
		// Alakzatok: kő: 0, papír: 1, olló: 2, gyík: 3, Spock: 4
		public string Nev { get; private set; }
		public int Ertek { get; private set; }
		public int Tipus { get; private set; }
		private static string[] nevek = { "kő", "papír", "olló", "gyík", "Spock" };
		private static Random vgen = new Random();
		public Alakzat(int tipus) {
			Tipus = tipus;
			Beallit(vgen.Next(0, tipus));
		}
		public Alakzat(int tipus, int ertek) {
			Tipus = tipus;
			Beallit(ertek);
		}
		public Alakzat(int tipus, string nev) {
			Tipus = tipus;
			Beallit(nev);
		}
		public void Beallit() {
			Beallit(vgen.Next(0, Tipus));
		}
		public void Beallit(int ertek) {
			Ertek = ertek >= 0 && ertek <= Tipus ? ertek : 0;
			Nev = nevek[ertek];
		}
		public void Beallit(string nev) {
			int talalat = Array.IndexOf(nevek, nev);
			Ertek = talalat != -1 ? talalat : 0;
			Nev = nevek[Ertek];
		}
	}
	class Jatekos {
		public string Nev { get; set; }
		public int NyertJatek { get; set; }
		public int VesztettJatek { get; set; }
		public int DontetlenJatek { get; set; }
		public int NyertKor { get; set; }
		public int VesztettKor { get; set; }
		public int DontetlenKor { get; set; }
		public Alakzat Alakzat { get; set; }
		public Jatekos(string nev) {
			Nev = nev;
			NyertJatek = 0;
			VesztettJatek = 0;
			DontetlenJatek = 0;
			NyertKor = 0;
			VesztettKor = 0;
			DontetlenKor = 0;
		}
		public Jatekos(string sor, bool torol) {
			string[] adatok = sor.Split(';');
			Nev = adatok[0];
			NyertJatek = torol ? 0 : Convert.ToInt32(adatok[1]);
			VesztettJatek = torol ? 0 : Convert.ToInt32(adatok[2]);
			DontetlenJatek = torol ? 0 : Convert.ToInt32(adatok[3]);
			NyertKor = 0;
			VesztettKor = 0;
			DontetlenKor = 0;
		}
		public void Valaszt(int tipus) {
			Alakzat = new Alakzat(tipus);
		}
		public void Valaszt(int tipus, int ertek) {
			Alakzat = new Alakzat(tipus, ertek);
		}
		public void Valaszt(int tipus, string nev) {
			Alakzat = new Alakzat(tipus, nev);
		}
		public string Sorra() {
			return $"{Nev};{NyertJatek};{VesztettJatek};{DontetlenJatek}";
		}
	}
	class Jatek {
		private int Tipus { get; set; }
		private int KorGyoztes { get; set; }
		private Jatekos Jatekos { get; set; }
		private Jatekos Gep { get; set; }
		private List<Jatekos> Jatekosok = new List<Jatekos>();
		public Jatek() {
			JatekosokBetoltese();
			JatekosokBelepese();
			JatekosEredmeny();
			TipusValasztas();
			for (int kor = 1; kor <= Tipus; kor++) {
				System.Console.WriteLine($"{kor}/{Tipus} kör");
				AlakzatValasztas();
				KorEredmeny();
			}
			JatekEredmeny();
			JatekosEredmeny();
			JatekosokMentese();
		}
		private void JatekosokBetoltese() {
			foreach (string sor in File.ReadAllLines("jatekosok.txt")) {
				Jatekosok.Add(new Jatekos(sor, false));
			}
		}
		private void JatekosokBelepese() {
			System.Console.Write("Adja meg a nevét: ");
			string nev = Console.ReadLine();
			Jatekos = Jatekosok.Find(x => x.Nev == nev);
			if (Jatekos == null) {
				Jatekos = new Jatekos(nev);
				Jatekosok.Add(Jatekos);
			}
			Gep = new Jatekos("Gép");
		}
		private void TipusValasztas() {
			System.Console.WriteLine();
			System.Console.Write("Adja meg a játék típusát (3 vagy 5): ");
			Tipus = Convert.ToInt32(Console.ReadLine());
		}
		private void AlakzatValasztas() {
			System.Console.Write($"\tVálasszon alakzatot: ");
			Jatekos.Valaszt(Tipus, Console.ReadLine());
			Gep.Valaszt(Tipus);
			System.Console.WriteLine($"\t{Jatekos.Nev}: {Jatekos.Alakzat.Nev}, {Gep.Nev}: {Gep.Alakzat.Nev}");
		}
		private int Ertekeles(int ertek1, int ertek2) {
			// Értékelés: döntetlen: 0, alakzat1 nyert: 1, alakzat2 nyert: 2*/
			int[,] tablazat = {
					/*k  p  o  g  S*/
				/*k*/{0, 2, 1, 1, 2},
				/*p*/{1, 0, 2, 2, 1},
				/*o*/{2, 1, 0, 1, 2},
				/*g*/{2, 1, 2, 0, 1},
				/*S*/{1, 2, 1, 2, 0},
			};
			return tablazat[ertek1, ertek2];
		}
		private void KorEredmeny() {
			KorGyoztes = Ertekeles(Jatekos.Alakzat.Ertek, Gep.Alakzat.Ertek);
			System.Console.WriteLine($"\t{(KorGyoztes == 1 ? $"{Jatekos.Nev} nyert." : (KorGyoztes == 2 ? $"{Gep.Nev} nyert." : "Döntetlen."))}");
			if (KorGyoztes == 1) {
				Jatekos.NyertKor++;
				Gep.VesztettKor++;
			}
			else if (KorGyoztes == 2) {
				Jatekos.VesztettKor++;
				Gep.NyertKor++;
			}
			else {
				Jatekos.DontetlenKor++;
				Gep.DontetlenKor++;
			}
		}
		private void JatekEredmeny() {
			System.Console.WriteLine();
			System.Console.WriteLine("A játék köreinek eredménytáblázata:");
			System.Console.WriteLine($"\t{Jatekos.Nev} győztes körei: {Jatekos.NyertKor}");
			System.Console.WriteLine($"\t{Gep.Nev} győztes körei: {Gep.NyertKor}");
			System.Console.WriteLine($"\tDöntetlen körök száma: {Jatekos.DontetlenKor}");
			System.Console.WriteLine($"A játék abszolút győztese: {(Jatekos.NyertKor > Gep.NyertKor ? Jatekos.Nev : (Jatekos.NyertKor < Gep.NyertKor ? Gep.Nev : "nincs"))}");
			if (Jatekos.NyertKor > Gep.NyertKor)
				Jatekos.NyertJatek++;
			else if (Jatekos.NyertKor < Gep.NyertKor)
				Jatekos.VesztettJatek++;
			else
				Jatekos.DontetlenJatek++;
		}
		private void JatekosEredmeny() {
			System.Console.WriteLine();
			System.Console.WriteLine($"{Jatekos.Nev} eddigi eredményei:");
			System.Console.WriteLine($"\tNyert játékok száma: {Jatekos.NyertJatek}");
			System.Console.WriteLine($"\tVesztett játékok száma: {Jatekos.VesztettJatek}");
			System.Console.WriteLine($"\tDöntetlen játékok száma: {Jatekos.DontetlenJatek}");
		}
		private void JatekosokMentese() {
			List<string> sorok = new List<string>();
			foreach (Jatekos jatekos in Jatekosok) sorok.Add(jatekos.Sorra());
			File.WriteAllLines("jatekosok.txt", sorok);
		}
	}
}
