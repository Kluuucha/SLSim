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

            if (elementS == 5) piatka.IsChecked = true;
            else if (elementS == 10) dycha.IsChecked = true;
            else dwie.IsChecked = true;
         
            spt.Text = Settings.elementSize.ToString();
            if(Settings.numberOfSpecies ==1)  ilegatunkow.SelectedItem = jeden;
            else if (Settings.numberOfSpecies == 2) ilegatunkow.SelectedItem = dwa;
            else if (Settings.numberOfSpecies == 3) ilegatunkow.SelectedItem = trzy;
            else if (Settings.numberOfSpecies == 4) ilegatunkow.SelectedItem = cztery;
            else if (Settings.numberOfSpecies == 5) ilegatunkow.SelectedItem = piec;

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

        private void ResStats(object sender, RoutedEventArgs e)
        {
            Settings.xResolution = 100;
            Settings.yResolution = 50;
            Settings.elementSize = 10;
            Settings.foodNumber = 200;
            Settings.stepsPerTic = 10;
            Settings.maximumTicsPerSecond = 10;
            Settings.foodPerTic = 20;
            Settings.closedSystem = true;
            Settings.addNumberOfFoodPerTick = false;

            Simulation.speciesList[0].color = Colors.Red;
            Simulation.speciesList[0].name = "Gatunek 1";
            Simulation.speciesList[1].color = Colors.Blue;
            Simulation.speciesList[1].name = "Gatunek 2";
            Simulation.speciesList[2].color = Colors.Orange;
            Simulation.speciesList[2].name = "Gatunek 3";
            Simulation.speciesList[3].color = Colors.Violet;
            Simulation.speciesList[3].name = "Gatunek 4";
            Simulation.speciesList[4].color = Colors.White;
            Simulation.speciesList[4].name = "Gatunek 5";

            for (int i = 0; i < 5; i++)
            {
                Simulation.speciesList[i].speed = 3;
                Simulation.speciesList[i].maxValue = 50;
                Simulation.speciesList[i].seeRange = 7;
                Simulation.speciesList[i].power = 1;
                Simulation.speciesList[i].mutationChance = 0.5;
                Simulation.speciesList[i].breedingChance = 0.5;
                Simulation.speciesList[i].startingPopulation = 10;
                Simulation.speciesList[i].isCarnivore = false;
                Simulation.speciesList[i].isHerbivore = true;
            }

            mtps.Text = Settings.maximumTicsPerSecond.ToString();
            foodPerTick.Text = Settings.foodPerTic.ToString();
            food.Text = Settings.foodNumber.ToString();
            x.Text = Settings.xResolution.ToString();
            y.Text = Settings.yResolution.ToString();
            elementS = Settings.elementSize;

            if (elementS == 5) piatka.IsChecked = true;
            else if (elementS == 10) dycha.IsChecked = true;
            else dwie.IsChecked = true;

            spt.Text = Settings.elementSize.ToString();
            if (Settings.numberOfSpecies == 1) ilegatunkow.SelectedItem = jeden;
            else if (Settings.numberOfSpecies == 2) ilegatunkow.SelectedItem = dwa;
            else if (Settings.numberOfSpecies == 3) ilegatunkow.SelectedItem = trzy;
            else if (Settings.numberOfSpecies == 4) ilegatunkow.SelectedItem = cztery;
            else if (Settings.numberOfSpecies == 5) ilegatunkow.SelectedItem = piec;
        }
    }
}
