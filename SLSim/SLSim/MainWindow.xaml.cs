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
    public partial class MainWindow : Window
    {
        Plansza plansza;
        bool isCorrect = false;

        public MainWindow()
        {

            InitializeComponent();
            plansza = new Plansza(MyCanvas);

            Food.generateFood();
            Organism.generateOrganisms();
            
            plansza.rysujPlansze(Simulation.simulationGrid);

            //var drawing = new Thread(new ThreadStart(draw));
            //drawing.Start();


        }

        public void kd(object sender, KeyEventArgs e){
            if (e.Key == Key.Down) {
                plansza.czyscPlansze();

                for (int i=0;i<Settings.stepsPerTic;i++)
                    Simulation.nextStep();
                //isCorrect = false;

                plansza.rysujPlansze(Simulation.simulationGrid);
            }

        }

        public void draw()
        {
            while (true)
            {
                if (!isCorrect)
                {
                    plansza.czyscPlansze();
                    plansza.rysujPlansze(Simulation.simulationGrid);
                    isCorrect = true;
                }
            }
        }
    }
}
