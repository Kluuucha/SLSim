using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLSim
{
    class Simulation
    {
        public static Dictionary<int, SimObject> simulationGrid = new Dictionary<int, SimObject>();

        public static void generateOrganisms(int quantity) {
            for (int i = 0; i < quantity; i++) {
                Organism o = new Organism();
                addObject(o);
            }
        }

        public static void addObject(SimObject o) {
            simulationGrid.Add(o.key(), o);
        }
    }
}
