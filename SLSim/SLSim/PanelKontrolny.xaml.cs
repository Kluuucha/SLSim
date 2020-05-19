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
        int elementS = 0;
        double snr = 0;
        public PanelKontrolny()
        {
            InitializeComponent();
            food.Text = Settings.foodNumber.ToString();
            organism.Text = Settings.organismNumber.ToString();
            x.Text = Settings.xResolution.ToString();
            y.Text = Settings.yResolution.ToString();
            elementS = Settings.elementSize;
            snr = Settings.breedingChance;
            spt.Text = Settings.elementSize.ToString();
            snrs.Value = Settings.breedingChance;
        }

        private void Zapisz(object sender, RoutedEventArgs e)
        {
            int jedzenie = int.Parse(food.Text);
            Settings.foodNumber = jedzenie;
            int organizmy = int.Parse(organism.Text);
            Settings.organismNumber = organizmy;
            int newX = int.Parse(x.Text);
            Settings.xResolution = newX;
            int newY = int.Parse(y.Text);
            Settings.yResolution = newY;
            Settings.elementSize = elementS;
            Settings.breedingChance = snr;
            int newspt = int.Parse(spt.Text);
            Settings.stepsPerTic = newspt;
            Close();

        }

        private void piatka_Checked(object sender, RoutedEventArgs e)
        {
            elementS = 5;
        }

        private void dycha_Checked(object sender, RoutedEventArgs e)
        {
            elementS = 10;
        }

        private void dwie_Checked(object sender, RoutedEventArgs e)
        {
            elementS = 20;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double v = Math.Round(snrs.Value, 2);
            val.Text = v.ToString();
            snr = v;
        }
    }
}
