using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace kopapirollo
{
	/// <summary>
	/// Interaction logic for Page2.xaml
	/// </summary>
	public partial class Page2 : Page
	{
		Jatek jatek = new Jatek();
		public static int[] eddigiEredmenyLista;
		public Page2()
		{
			InitializeComponent();
			List<string> sorok = File.ReadAllLines("jatekosok.txt").ToList();
			Console.WriteLine(sorok.Count);
			nevEredmeny.Content = $"{Page1.enteredName} eddigi eredményei:";
			if (Page1.advancedMode) {
				gyikbutton.Visibility = Visibility.Visible;
				spockbutton.Visibility = Visibility.Visible;
			}
			eddigiEredmeny.Items.Add($"Nyert játékok száma: {eddigiEredmenyLista[0]}");
			eddigiEredmeny.Items.Add($"Vesztett játékok száma: {eddigiEredmenyLista[1]}");
			eddigiEredmeny.Items.Add($"Döntetlen játékok száma: {eddigiEredmenyLista[2]}");
		}
		
		public static int menetek = 5;
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			jatek.ujKor(menetek);
			string korSzoveg = "";
			switch (jatek.KorGyoztes) {
				case 0:
					korSzoveg = "Döntetlen";
					break;
				case 1:
					korSzoveg = "Játékos nyert";
					break;
				case 2:
					korSzoveg = "Gép nyert";
					break;
				default:
					break;
			}
			if (menetek > 1) {
				menetek--;
				Menetgomb.Content = $"OK {menetek}/5";
				menetEredmeny.Items.Add(korSzoveg);
			}
			else if (menetek == 1) {
				Menetgomb.Content = "Vége!";
				menetek--;
				menetEredmeny.Items.Add(korSzoveg);
			}

			else {
				Page3 page3 = new Page3();
				NavigationService.Navigate(page3);
			}

		}

		public static int valasztottAlakzat;
		private void kobutton_Click(object sender, RoutedEventArgs e) {
			valasztottAlakzat = 0;
			valasztott.Content = "Kő";
		}

		private void papirbutton_Click(object sender, RoutedEventArgs e) {
			valasztottAlakzat = 1;
            valasztott.Content = "Papír";
        }

		private void ollobutton_Click(object sender, RoutedEventArgs e) {
			valasztottAlakzat = 2;
            valasztott.Content = "Olló";
        }

		private void gyikbutton_Click(object sender, RoutedEventArgs e) {
			valasztottAlakzat = 3;
            valasztott.Content = "Gyík";
        }

		private void spockbutton_Click(object sender, RoutedEventArgs e) {
			valasztottAlakzat = 4;
            valasztott.Content = "Spock";
        }

		private void eddigiEredmeny_SelectionChanged(object sender, SelectionChangedEventArgs e) {

		}

		private void ListBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e) {

		}
	}
}
