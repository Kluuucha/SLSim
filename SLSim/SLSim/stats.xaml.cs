using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
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
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class stats: Window
    {
        Organism pom;
        int gat1 = 0;
        int gat2 = 0;
        int gat5 = 0;
        int gat3 = 0;
        int gat4 = 0;
        int ileNaPlaszy = 0;

        public stats()
        {
            InitializeComponent();

            if (Settings.numberOfSpecies == 1)
            {
                dwa.Visibility = Visibility.Hidden;
                trzy.Visibility = Visibility.Hidden;
                cztery.Visibility = Visibility.Hidden;
                piec.Visibility = Visibility.Hidden;
            }
            else if (Settings.numberOfSpecies == 2)
            {
                trzy.Visibility = Visibility.Hidden;
                cztery.Visibility = Visibility.Hidden;
                piec.Visibility = Visibility.Hidden;
            }
            else if (Settings.numberOfSpecies == 3)
            {
                cztery.Visibility = Visibility.Hidden;
                piec.Visibility = Visibility.Hidden;
            }
            else if (Settings.numberOfSpecies == 4)
            {
                piec.Visibility = Visibility.Hidden;
            }


            iloscOrganizmow.Text = Simulation.simulationGrid.Where(kpv => kpv.Value is Organism).Count().ToString();
            iloscPozywienia.Text = Simulation.simulationGrid.Where(kpv => kpv.Value is Food).Count().ToString();
            iloscGatonkowPocz.Text = Settings.numberOfSpecies.ToString();
            krokiNaTick.Text = Settings.stepsPerTic.ToString();


            foreach (KeyValuePair<int, SimObject> kvp in Simulation.simulationGrid)
            {
                if (kvp.Value is Organism)
                {
                    pom = (Organism)kvp.Value;
                    if (pom.species.Equals(Simulation.speciesList[0])) gat1++;
                    if (pom.species.Equals(Simulation.speciesList[1])) gat2++;
                    if (pom.species.Equals(Simulation.speciesList[2])) gat3++;
                    if (pom.species.Equals(Simulation.speciesList[3])) gat4++;
                    if (pom.species.Equals(Simulation.speciesList[4])) gat5++;
                }
            }
            if (gat1 > 0) ileNaPlaszy++;
            if (gat2 > 0) ileNaPlaszy++;
            if (gat3 > 0) ileNaPlaszy++;
            if (gat4 > 0) ileNaPlaszy++;
            if (gat5 > 0) ileNaPlaszy++;
            iloscGatonkowNaPlanszy.Text = ileNaPlaszy.ToString();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
