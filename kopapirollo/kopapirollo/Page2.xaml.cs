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

		public Page2()
		{
			InitializeComponent();
			List<string> sorok = File.ReadAllLines("jatekosok.txt").ToList();
			Console.WriteLine(sorok.Count);
			nevEredmeny.Content = $"{Page1.enteredName} eddigi eredményei:";
		}

		public static void eddigiEredmenyBeiras(int[] sor) {
			/* eddigi eredmeny beirasa felso tablaba */
		}

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
		{

		}

		private void ListBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
		{

		}

		public static int menetek = 5;
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			jatek.ujKor(menetek);
			if (menetek > 1) {
				menetek--;
				Menetgomb.Content = $"OK {menetek + 1}/5";
			}
			else {
				if (menetek == 1) {
					Menetgomb.Content = "Vége!";
					menetek--;
				}
				else {
					Page3 page3 = new Page3();
					NavigationService.Navigate(page3);
				}
			}
		}
	}
}
