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
        public Color color { get; set; }
        public string name { get;  set; }
        public int startingPopulation { get;  set; }
        public double breedingChance { get;  set; }
        public bool isCarnivore { get;  set; }
        public bool isHerbivore { get;  set; }

        public int maxValue { get;  set; }
        public int speed { get;  set; }

        public int power { get;  set; }

        public int seeRange { get;  set; }

        public double mutationChance { get;  set; }


        public Species(Color color, string name = "Species", int speed = 3, int maxValue = 50, int seeRange = 7, int power = 1,  double mutationChance = 0.5, double breedingChance = 0.5, int startingPopulation = 10, bool isCarnivore = false, bool isHerbivore = true) {

            this.name = name;
            this.color = color;
            this.breedingChance = breedingChance;
            this.startingPopulation = startingPopulation;
            this.isCarnivore = isCarnivore;
            this.isHerbivore = isHerbivore;
            this.maxValue = maxValue;
            this.speed = speed;
            this.power = power;
            this.seeRange = seeRange;
            this.mutationChance = mutationChance;
        }
    }
}
