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
        public static IList<Organism> organisms = new IList<Organism>();
        public static IList<Pozywienie> food = new IList<Pozywienie>();
       
    }
}
