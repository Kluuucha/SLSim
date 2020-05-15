using System;
using System.Windows.Shapes;

namespace SLSim
{
    public class Food : SimObject
    {
        public int value { get; private set; }

        public static Food newRandomFood(int value = 1)
        {
            Random random = new Random();

            Food temp = new Food(value);
            int key = 0;

            do
            {
                
                temp.posX = random.Next(Settings.xResolution - 1);
                temp.posY = random.Next(Settings.yResolution - 1);
                key = temp.key();
            }
            while (Simulation.simulationGrid.ContainsKey(key));
            Simulation.simulationGrid.Add(key, temp);
            return temp;
        }
        public static void generateFood()
        {
            for (int i = 0; i < Settings.foodNumber; i++)
                newRandomFood();
        }
        private Food(int value) { this.value = 1; }

        public Food(int x, int y, int value = 1)
        {
            posX = x;
            posY = y;
            this.value = value;
        }
    }
}