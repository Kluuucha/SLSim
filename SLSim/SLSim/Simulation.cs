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

        public static void generateOrganisms(int quantity) {
            for (int i = 0; i < quantity; i++) {
                Organism o = new Organism();
                addObject(o);
            }
        }

        public static void addObject(SimObject o) {
            simulationGrid.Add(o.key(), o);
        }

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
