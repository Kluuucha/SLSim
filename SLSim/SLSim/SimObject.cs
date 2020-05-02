using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLSim
{
    public abstract class SimObject
    {
        public int posX;
        public int posY;
        public int key() { return posX + posY * Settings.xResolution; }
        public int key(int posX,int posY) { return posX + posY * Settings.xResolution; }
    }
}
