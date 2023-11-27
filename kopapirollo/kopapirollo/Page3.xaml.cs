﻿using System;
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
        public Page3()
        {
            InitializeComponent();
            //Menet
            menetEredmenyeVeg.Items.Add($"{Page1.enteredName} győztes körei: {""}");
            menetEredmenyeVeg.Items.Add($"Gép győztes körei: {""}");
            menetEredmenyeVeg.Items.Add($"Döntetlen körök száma: {""}");
            menetEredmenyeVeg.Items.Add($"A játék abszolút győztese: //kérdőjeles string kérdés kéne//");

            //Név
            nevVegleges.Content = $"{Page1.enteredName} eddigi eredményei:";

            //Összes
            osszEddigiEredmeny.Items.Add($"Nyert játékok száma: {""}");
            osszEddigiEredmeny.Items.Add($"Vesztett játékok száma: {""}");
            osszEddigiEredmeny.Items.Add($"Döntetlen játékok száma: {""}");
        }
    }
}
