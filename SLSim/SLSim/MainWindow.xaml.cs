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
            plansza =  new Plansza(MyCanvas);

            Simulation.generateOrganisms(1);
            Food.generateFood();
            Organism.generateOrganisms();
            plansza.rysujPlansze(Simulation.simulationGrid);
            
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
        public void kd(object sender, KeyEventArgs e){
            if (e.Key == Key.Down) {
                plansza.czyscPlansze();
                Simulation.nextStep();
                plansza.rysujPlansze(Simulation.simulationGrid);
            }

        }
    }
}
