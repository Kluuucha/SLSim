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
using System.Windows.Shapes;

namespace SLSim
{
    /// <summary>
    /// Logika interakcji dla klasy PanelKontrolny.xaml
    /// </summary>
    public partial class PanelKontrolny : Window
    {
        public PanelKontrolny()
        {
            InitializeComponent();
            food.Text = Settings.foodNumber.ToString();
            organism.Text = Settings.organismNumber.ToString();
        }

        private void Zapisz(object sender, RoutedEventArgs e)
        {
           int jedzenie = int.Parse(food.Text);
           Settings.foodNumber = jedzenie;
           int organizmy = int.Parse(organism.Text);
           Settings.organismNumber = organizmy;
           Close();
        }
    }
}
