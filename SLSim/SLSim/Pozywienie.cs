namespace SLSim
{
    internal class Pozywienie
    {
        private int x;
        private int y;
        //wartosc - wartość punktowa zdobywana po zjedzeniu pożywienia - domyślnie 1;
        private int wartosc;

        public Pozywienie(int x, int y)
        {
            this.x = x;
            this.y = y;
            wartosc = 1;
        }
        public Pozywienie(int x, int y, int wartosc)
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
    }
}