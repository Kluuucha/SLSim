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
        int elementS = 10;
        bool addfpt = false;
        public PanelKontrolny()
        {
            InitializeComponent();
            mtps.Text = Settings.maximumTicsPerSecond.ToString();
            foodPerTick.Text = Settings.foodPerTic.ToString();
            food.Text = Settings.foodNumber.ToString();
            x.Text = Settings.xResolution.ToString();
            y.Text = Settings.yResolution.ToString();
            elementS = Settings.elementSize;
         
            spt.Text = Settings.elementSize.ToString();
            ilegatunkow.SelectedItem = jeden;
        }

        private void Zapisz(object sender, RoutedEventArgs e)
        {
            if(addfpt) Settings.foodPerTic = int.Parse(foodPerTick.Text);
           

            Settings.maximumTicsPerSecond = int.Parse(mtps.Text);
            int jedzenie = int.Parse(food.Text);
            Settings.foodNumber = jedzenie;
            int newX = int.Parse(x.Text);
            Settings.xResolution = newX;
            int newY = int.Parse(y.Text);
            Settings.yResolution = newY;
            Settings.elementSize = elementS;
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

        private void spiciesStats(object sender, RoutedEventArgs e)
        {
            if (ilegatunkow.SelectedItem == jeden) Settings.numberOfSpecies = 1;
            if (ilegatunkow.SelectedItem == dwa) Settings.numberOfSpecies = 2;
            if (ilegatunkow.SelectedItem == trzy) Settings.numberOfSpecies = 3;
            if (ilegatunkow.SelectedItem == cztery) Settings.numberOfSpecies = 4;
            if (ilegatunkow.SelectedItem == piec) Settings.numberOfSpecies = 5;
            PanelGatunkow panelGatunkow = new PanelGatunkow();
            panelGatunkow.Show();
        }

        private void stalaIlosc(object sender, RoutedEventArgs e)
        {
            Settings.closedSystem = true;
            Settings.addNumberOfFoodPerTick = false;
            addfpt = false;
            foodPerTick.Visibility = Visibility.Hidden;
        }
        public void AddNumberOfFood(object sender, RoutedEventArgs e)
        {
            Settings.closedSystem = false;
            Settings.addNumberOfFoodPerTick = true;
            addfpt = true;
            foodPerTick.Visibility = Visibility.Visible;
        }
    }
}
