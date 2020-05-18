using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLSim
{
    class Simulation
    {
        public static Random random = new Random();
        public static Dictionary<int, SimObject> simulationGrid = new Dictionary<int, SimObject>();

        public static void nextStep()
        {
            List<Organism> organisms = new List<Organism>();
            foreach(KeyValuePair<int, SimObject> kvp in simulationGrid)
                if (kvp.Value is Organism)
                {
                    organisms.Add((Organism)kvp.Value);
                }
            foreach(Organism o in organisms)
            {
                if (simulationGrid.ContainsKey(o.key()))
                {
                    o.act();
                }
            }
        }
    }
}
