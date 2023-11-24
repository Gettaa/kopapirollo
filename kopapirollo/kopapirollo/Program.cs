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

		public void Beallit() {
			Beallit(vgen.Next(0, Tipus));
		}

		public void Beallit(int ertek) {
			Ertek = ertek >= 0 && ertek <= Tipus ? ertek : 0;
			Nev = nevek[ertek];
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
            Page2.eddigiEredmenyBeiras(new int[] { Jatekos.NyertJatek, Jatekos.VesztettJatek, Jatekos.DontetlenJatek });
            Tipus = Page1.advancedMode ? 4 : 2;
			/*
			for (int kor = 1; kor <= 5; kor++) {
				
				AlakzatValasztas();
				KorEredmeny();
			}
			JatekEredmeny();
			Page2.eddigiEredmenyBeiras(new int[] { Jatekos.NyertJatek, Jatekos.VesztettJatek, Jatekos.DontetlenJatek });
			JatekosokMentese();
			*/
		}

		public void ujKor(int menetek) {
			if (menetek > 1) {
                AlakzatValasztas();
                KorEredmeny();
            }
			if (menetek == 1) {
				JatekEredmeny();
				Page2.eddigiEredmenyBeiras(new int[] { Jatekos.NyertJatek, Jatekos.VesztettJatek, Jatekos.DontetlenJatek });
				JatekosokMentese();
			}
			else throw new Exception("Körszám out of range");
		}

		private void JatekosokBetoltese() {
			foreach (string sor in File.ReadAllLines("jatekosok.txt")) {
				Jatekosok.Add(new Jatekos(sor, false));
			}
		}

		private void JatekosokBelepese() {
			string nev = Page1.enteredName;
			Jatekos = Jatekosok.Find(x => x.Nev == nev);
			if (Jatekos == null) {
				Jatekos = new Jatekos(nev);
				Jatekosok.Add(Jatekos);
			}
			Gep = new Jatekos("Gép");
		}

		private void AlakzatValasztas() {
			Jatekos.Valaszt(Tipus /*, kivalasztott alakzat listabol*/);
			Gep.Valaszt(Tipus);
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
			/*eredmeny elkuldese*/
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
			/*jatek eredmeny elkuldese*/
			if (Jatekos.NyertKor > Gep.NyertKor) Jatekos.NyertJatek++;
			else if (Jatekos.NyertKor < Gep.NyertKor) Jatekos.VesztettJatek++;
			else Jatekos.DontetlenJatek++;
		}

		private void JatekosokMentese() {
			List<string> sorok = new List<string>();
			foreach (Jatekos jatekos in Jatekosok) sorok.Add(jatekos.Sorra());
			File.WriteAllLines("jatekosok.txt", sorok);
		}
	}
}
