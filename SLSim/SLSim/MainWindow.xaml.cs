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
            Simulation.generateOrganisms(1);
            Food.generateFood();
            Organism.generateOrganisms();
            plansza.rysujPlansze(Simulation.simulationGrid);
            NT.Visibility = Visibility.Visible;
        }

        private void nextTik(object sender, RoutedEventArgs e)
        {
            plansza.czyscPlansze();
            //for(int i=0;i<10;i++)
            Simulation.nextStep();
            plansza.rysujPlansze(Simulation.simulationGrid);
        }
    }
}
