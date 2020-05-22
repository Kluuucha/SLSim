using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SLSim
{
    class Simulation
    {
        public static Random random = new Random();
        public static int deficit = 0, foodValue = 5, foodPerTick=10;
        public static Dictionary<int, SimObject> simulationGrid = new Dictionary<int, SimObject>();
        public static DispatcherTimer t1 = new System.Windows.Threading.DispatcherTimer();
        public static bool enclosedSystem = true;
        public static int mutationChance = 50;
        public static void generateOrganisms(int quantity, Species spec) {
            for (int i = 0; i < quantity; i++) {
                Organism.generateOrganisms(spec);
            }
        }

        public static void addObject(SimObject o) {
            simulationGrid.Add(o.key(), o);
        }

        public static void nextStep()
        {
            List<Organism> organisms = new List<Organism>();
            organisms = organisms.OrderBy(x => x.speed).ToList();
            foreach(KeyValuePair<int, SimObject> kvp in simulationGrid)
                if (kvp.Value is Organism)
                {
                    organisms.Add((Organism)kvp.Value);
                }
            foreach(Organism o in organisms)
            {
                if (simulationGrid.ContainsKey(o.key()) && o == simulationGrid[o.key()])
                {
                    o.act();
                }
            }
            if (enclosedSystem) {
                Food.generateFood((int)(deficit / foodValue));
                deficit %= foodValue;
            }else{
                Food.generateFood(foodPerTick);
            }

        }
    }
}
