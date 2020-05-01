using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLSim
{
    public abstract class SimObject
    {
        protected int posX, posY;

        public int key() {
            return encode(posX, posY);
        }

        public int encode(int x, int y)
        {
            return x + y * Settings.xResolution;
        }

        public int getX()
        {
            return posX;
        }

        public int getY()
        {
            return posY;
        }

        public void setX(int posX)
        {
            this.posX = posX;
        }

        public void setY(int posY)
        {
            this.posY = posY;
        }

        public Tuple<int, int> getPosition()
        {
            return Tuple.Create(posX, posY);
        }

        public void getPosition(Tuple<int, int> position)
        {
            this.posX = position.Item1;
            this.posY = position.Item2;
        }
    }
}
