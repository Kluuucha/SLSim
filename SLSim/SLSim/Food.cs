using System.Windows.Shapes;

namespace SLSim
{
    public class Food
    {
        private int x;
        private int y;
        //wartosc - wartość punktowa zdobywana po zjedzeniu pożywienia - domyślnie 1;
        private int wartosc;

        public Food(int x, int y)
        {
            this.x = x;
            this.y = y;
            wartosc = 1;
        }


        public Food(int x, int y, int wartosc)
        {
            this.x = x;
            this.y = y;
            this.wartosc = wartosc;
        }


        public int getWartosc()
        {
            return wartosc;
        }
        public void setWartosc(int wartosc)
        {
            this.wartosc = wartosc;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

    }
}