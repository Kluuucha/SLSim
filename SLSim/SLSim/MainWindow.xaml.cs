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
using System.Threading;

namespace SLSim
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //FoodGeneration generowaniePozywienia;
        Plansza plansza;

        public MainWindow()
        {

            InitializeComponent();

            
            /* commit - pozywienie v1:
             *  - na razie generowane tylko raz - trzeba dodać następne wywołania co określoną ilość czasu
             *  - na razie podane wartości rozmiaru mapy i ilości na sztywno
             *  
             */
            /*generowaniePozywienia = new FoodGeneration(10, MyCanvas, 980, 460);
            generowaniePozywienia.generujPozywienie();
            /*GenerowaniePozywienia generowaniePozywienia = new GenerowaniePozywienia(5,10, MyCanvas, 980, 460);
            generowaniePozywienia.generujPozywienieLosowa();*/

        }



        private void otworzPanelKontrolny(object sender, RoutedEventArgs e)
        {
            PanelKontrolny panel = new PanelKontrolny();
            panel.Show();

        }

        private void StartSymulacji(object sender, RoutedEventArgs e)
        {
            plansza = new Plansza(MyCanvas);

            Species spec1 = new Species(Colors.Red,"Species 1", Settings.breedingChance, Settings.organismNumber, true, true);
            Species spec2 = new Species(Colors.Blue, "Species 2", Settings.breedingChance, Settings.organismNumber);
            Species spec3 = new Species(Colors.Orange, "Species 3", Settings.breedingChance, Settings.organismNumber);

            Food.generateFood();

            Organism.generateOrganisms(spec1);
            Organism.generateOrganisms(spec2);
            Organism.generateOrganisms(spec3);

            plansza.rysujPlansze(Simulation.simulationGrid);
            NT.Visibility = Visibility.Visible;
            PT.Visibility = Visibility.Hidden;
            S.Visibility = Visibility.Visible;
        }

        private void nextTik(object sender, RoutedEventArgs e)
        {
            plansza.czyscPlansze();
            for(int i=0;i<Settings.stepsPerTic;i++)
                Simulation.nextStep();
            plansza.rysujPlansze(Simulation.simulationGrid);
        }
        private void showStats(object sender, RoutedEventArgs e)
        {
            stats s = new stats();
            s.Show();
        }
    }
}
