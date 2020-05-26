using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLSim
{
    public static class Settings
    {
        public static int xResolution = 100;
        public static int yResolution = 50;
        public static int elementSize = 10;
        public static int foodNumber = 200;
        public static int stepsPerTic = 10;
        public static int maximumTicsPerSecond = 10;
        public static int foodPerTic = 20;
        public static int numberOfSpecies = 1;

        public static bool closedSystem = true;
        public static bool addNumberOfFoodPerTick = false;

        //TODO: usunąć po wprowadzeniu panelu edycji pojedynczego gatunku
       // public static int organismNumber = 10; //przeniesione do Species.startingPopulation 
        //public static double breedingChance = 0.5; //przeniesione do Species.breedingChance
    }
}
