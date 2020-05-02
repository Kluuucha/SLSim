using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SLSim
{
    class Simulation
    {
        public Simulation(){}
           
        public static Dictionary<int, SimObject> simulationGrid = new Dictionary<int, SimObject>();

        /* wiem że Dawid mówił że w C# się robi inaczej ale nie do końca wiedziałem jak się odwołać a jest mi to potrzebne */
        public Dictionary<int, SimObject> getDictionary(){
        return simulationGrid;
        }

        /*
         * Generowanie obiektów w celach testowych
         */

        public void generowanieTestowe(){
            SimObject a = new Organism(900,500);
            simulationGrid.Add(1,a);
            a = new Organism(50,200);
            simulationGrid.Add(2,a);
            a= new Food(200,700);
            simulationGrid.Add(3,a);

        }
     }
}
