using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SLSim
{
    public class Species
    {
        public Color color { get; private set; }
        public string name { get; private set; }
        public int startingPopulation { get; private set; }
        public double breedingChance { get; private set; }
        public bool isCarnivore { get; private set; }
        public bool isHerbivore { get; private set; }

        public Species(Color color, string name = "Species", double breedingChance = 0.5, int startingPopulation = 10, bool isCarnivore = false, bool isHerbivore = true) {

            this.name = name;
            this.color = color;
            this.breedingChance = breedingChance;
            this.startingPopulation = startingPopulation;
            this.isCarnivore = isCarnivore;
            this.isHerbivore = isHerbivore;
        }
    }
}
