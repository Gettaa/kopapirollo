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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void checkStart() {
            if (name.Text.Length > 0) {
                start.IsEnabled = true;
            } else {
                start.IsEnabled = false;
            }
        }

        // gamemode1
        private void RadioButton_Checked(object sender, RoutedEventArgs e) {

        }

        // gamemode2
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e) {

        }

        // start
        private void Button_Click(object sender, RoutedEventArgs e) {

        }

        // name
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {
            checkStart();
        }
    }
}
