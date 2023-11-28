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

namespace kopapirollo
{
	/// <summary>
	/// Interaction logic for Page3.xaml
	/// </summary>
	public partial class Page3 : Page
	{
		public static int[] menetStat;
		public static int[] eddigiStat;
        public Page3()
		{
			InitializeComponent();
			//Menet
			string[] gyoztesSzoveg = { "Döntetlen", Page1.enteredName, "Gép"};
			menetEredmenyeVeg.Items.Add($"{Page1.enteredName} győztes körei: {menetStat[0]}");
			menetEredmenyeVeg.Items.Add($"Gép győztes körei: {menetStat[1]}");
			menetEredmenyeVeg.Items.Add($"Döntetlen körök száma: {menetStat[2]}");
			menetEredmenyeVeg.Items.Add($"A játék abszolút győztese: {gyoztesSzoveg[menetStat[3]]}");

			//Név
			nevVegleges.Content = $"{Page1.enteredName} eddigi eredményei:";

			//Összes
			osszEddigiEredmeny.Items.Add($"Nyert játékok száma: {eddigiStat[0]}");
			osszEddigiEredmeny.Items.Add($"Vesztett játékok száma: {eddigiStat[1]}");
			osszEddigiEredmeny.Items.Add($"Döntetlen játékok száma: {eddigiStat[2]}");
		}

<<<<<<< Updated upstream
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Page2 page2 = new Page2();
			NavigationService.Navigate(page2);
		}
	}
=======
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page2 page2 = new Page2();
            NavigationService.Navigate(page2);
            Page2.menetek = 5;
        }
    }
>>>>>>> Stashed changes
}
