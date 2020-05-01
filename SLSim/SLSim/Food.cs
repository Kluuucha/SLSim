using System.Windows.Shapes;

namespace SLSim
{
    public class Food : SimObject
    {
        //value - wartość punktowa zdobywana po zjedzeniu pożywienia - domyślnie 1;
        private int value;

        public Food(int x, int y)
        {
            this.posX = x;
            this.posY = y;
            value = 1;
        }


        public Food(int x, int y, int value)
        {
            this.posX = x;
            this.posY = y;
            this.value = value;
        }


        public int getValue()
        {
            return value;
        }
        public void setValue(int value)
        {
            this.value = value;
        }
    }
}