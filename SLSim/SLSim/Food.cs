using System;
using System.Windows.Shapes;

namespace SLSim
{
    public class Food : SimObject
    {
        public int wartosc { get; private set; }

        public static Food newRandomFood(int value = 1) {
            Food temp = new Food(value);
            int key=0;
            do
            {   
                Random random = new Random();
                temp.posX = random.Next(Settings.xResolution-1);
                temp.posY = random.Next(Settings.yResolution - 1);
                key = temp.key();
            } while (Simulation.simulationGrid[key] != null);
            Simulation.simulationGrid.Add(key, temp);
            return temp;
        }
        public static void generateFood()
        {
            for (int i = 0; i < Settings.foodNumber; i++)
                newRandomFood();
        }
        private Food(int value) { wartosc = 1; }

        public Food(int x, int y, int wartosc =1)//uwaga, nie obsługuje operacji na słowniku!
        {
            posX = x;
            posY = y;
            this.wartosc = wartosc;
        }
    }
}