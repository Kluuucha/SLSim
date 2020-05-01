using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic.Dictionary;

namespace SLSim
{
    public class Settings
    {
        public static int xResolution = 1000;
        public static int yResolution = 500;
    }
    public class ProgramData
    {
        public static Dictionary<int,Organism> organisms = new HashSet<int,Organism>();
        public static HashSet<int,Food> food = new HashSet<int,Food>();
       
    }
}
