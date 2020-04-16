using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SLSim
{
    public class Settings
    {
        public static int xResolution = 1000;
        public static int yResolution = 500;
    }
    public class ProgramData
    {
        public static List<Organism> organisms = new List<Organism>();
        public static List<Food> food = new List<Food>();
       
    }
}
