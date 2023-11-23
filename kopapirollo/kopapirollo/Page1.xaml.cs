using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
	public partial class Page1 : Page
	{
		public Page1()
		{
			InitializeComponent();
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (nev.Text.Length > 0) start.IsEnabled = true;
			else start.IsEnabled = false;
			
		}
		public static string enteredName;

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (gamemode1.IsChecked == true || gamemode2.IsChecked == true) 
			{
				enteredName = nev.Text;
				Page2 page2 = new Page2();
				NavigationService.Navigate(page2);
			}
		}

		private void RadioButton_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
		{

		}
	}
}
