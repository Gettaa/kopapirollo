using System;
using System.Collections;
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
using System.Xml.Linq;

namespace kopapirollo
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    private void checkStart()
    {
        if (name.Text.Length > 0)
        {
            start.IsEnabled = true;
        }
        else
        {
            start.IsEnabled = false;
        }
    }

    // gamemode1
    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {

    }

    // gamemode2
    private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
    {

    }

    // start
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //NavigationWindow window = new NavigationWindow();
        //window.Source = new Uri("Page1.xaml", UriKind.Relative);
        //window.Show();
    }

    // name
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        checkStart();
    }
}
