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
    /// Logika interakcji dla klasy PanelGatunkow.xaml
    /// </summary>
    public partial class PanelGatunkow : Window
    {
        double szansaNamutacje;
        bool miesozerca = false;
        bool roslinozerca = true;
        int maxSpeed;
        int power;
        int range;


        public PanelGatunkow()
        {
            InitializeComponent();
            if(Settings.numberOfSpecies == 1)
            {
                dwa.Visibility = Visibility.Hidden;
                trzy.Visibility = Visibility.Hidden;
                cztery.Visibility = Visibility.Hidden;
                piec.Visibility = Visibility.Hidden;
            }
            else if(Settings.numberOfSpecies == 2)
            {
                trzy.Visibility = Visibility.Hidden;
                cztery.Visibility = Visibility.Hidden;
                piec.Visibility = Visibility.Hidden;
            }
            else if(Settings.numberOfSpecies == 3)
            {
                cztery.Visibility = Visibility.Hidden;
                piec.Visibility = Visibility.Hidden;
            }
            else if(Settings.numberOfSpecies == 4)
            {
                piec.Visibility = Visibility.Hidden;
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            szansaNamutacje = Math.Round(szansaNaMutacjeSlider.Value,2);
            SzansaNaMutacjeValue.Text = (szansaNamutacje*100).ToString()+"%";

        }
    }
}
