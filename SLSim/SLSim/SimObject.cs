using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SLSim
{
    public abstract class SimObject
    {
        public int posX { get; protected set; }
        public int posY { get; protected set; }

        public int key() {
            return encode(posX, posY);
        }

        public int encode(int x, int y)
        {
            return x + y * Settings.xResolution;
        }

       
        public Tuple<int, int> getPosition()
        {
            return Tuple.Create(posX, posY);
        }

        public void setPosition(Tuple<int, int> position)
        {
            this.posX = position.Item1;
            this.posY = position.Item2;
        }
    }
}
