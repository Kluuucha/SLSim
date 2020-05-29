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
using System.Windows.Threading;

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
            Simulation.speciesList[0] = new Species(Colors.Red, "Gatunek 1");
            Simulation.speciesList[1] = new Species(Colors.Blue, "Gatunek 2");
            Simulation.speciesList[2] = new Species(Colors.Orange, "Gatunek 3");
            Simulation.speciesList[3] = new Species(Colors.Violet, "Gatunek 4");
            Simulation.speciesList[4] = new Species(Colors.White, "Gatunek 5");
        }
        private void otworzPanelKontrolny(object sender, RoutedEventArgs e)
        {
            PanelKontrolny panel = new PanelKontrolny();
            panel.Show();
        }

        private void StartSymulacji(object sender, RoutedEventArgs e)
        {
            plansza = new Plansza(MyCanvas);
            Simulation.t1 = new System.Windows.Threading.DispatcherTimer();


            Food.generateFood();

            for(int i = 0; i < Settings.numberOfSpecies; i++)
            {
                Organism.generateOrganisms(Simulation.speciesList[i]);
            }


            plansza.rysujPlansze(Simulation.simulationGrid);
            NT.Visibility = Visibility.Visible;
            PT.Visibility = Visibility.Hidden;
            S.Visibility = Visibility.Visible;


            startSym.Visibility = Visibility.Visible;
            start.Visibility = Visibility.Hidden;
            Restart.Visibility = Visibility.Visible;
           

            

        }

        private void StartSymulacjiWCzasieRzeczywistym(object sender, RoutedEventArgs e)
        {
            Simulation.t1.Interval = TimeSpan.FromMilliseconds(1000/Settings.maximumTicsPerSecond);
            Simulation.t1.IsEnabled = true;
            Simulation.t1.Tick += new EventHandler(dispatcherTimer_Tick);
            Simulation.t1.Start();

            startSym.Visibility = Visibility.Hidden;
            pauza.Visibility = Visibility.Visible;
            S.Visibility = Visibility.Hidden;
            NT.Visibility = Visibility.Hidden;
            Restart.Visibility = Visibility.Hidden;
           
        }

        private void StopSymulacjiWCzasieRzeczywistym(object sender, RoutedEventArgs e)
        {
            Simulation.t1.Stop();
            startSym.Visibility = Visibility.Visible;
            pauza.Visibility = Visibility.Hidden;
            S.Visibility = Visibility.Visible;
            NT.Visibility = Visibility.Visible;
            Restart.Visibility = Visibility.Visible;
        }

        

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {       
             plansza.czyscPlansze();
            for (int i = 0; i < Settings.stepsPerTic; i++)
                Simulation.nextStep();
            plansza.rysujPlansze(Simulation.simulationGrid);
            
        }


        private void nextTik(object sender, RoutedEventArgs e)
        {    
            plansza.czyscPlansze();
            for (int i = 0; i < Settings.stepsPerTic; i++)
                Simulation.nextStep();
            plansza.rysujPlansze(Simulation.simulationGrid);
        }

        
        private void showStats(object sender, RoutedEventArgs e)
        {
            stats s = new stats();
            s.Show();
        }

        private void RestartSym(object sender, RoutedEventArgs e)
        {
            Simulation.t1.Stop();
            plansza.czyscPlansze();
            Simulation.simulationGrid.Clear();
            NT.Visibility = Visibility.Hidden;
            PT.Visibility = Visibility.Visible;
            S.Visibility = Visibility.Hidden;
            startSym.Visibility = Visibility.Hidden;
            start.Visibility = Visibility.Visible;
            Restart.Visibility = Visibility.Hidden;
            pauza.Visibility = Visibility.Hidden;
        

        }
    }
}
