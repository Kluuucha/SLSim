using System;
using System.Windows.Shapes;

namespace SLSim
{
    public class Food : SimObject
    {
        public int value { get; private set; }
        public static Food newRandomFood(int value = 5)
        {
            Food temp = new Food(value);
            int key = 0;
            do
            {
                
                temp.posX = Simulation.random.Next(Settings.xResolution - 1);
                temp.posY = Simulation.random.Next(Settings.yResolution - 1);
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
        public static void generateFood(int n,int value)
        {
            for (int i = 0; i < n; i++)
                newRandomFood(value);
        }
        private Food(int value = 5) { this.value = value; }

        public Food(int x, int y, int value = 5)
        {
            posX = x;
            posY = y;
            this.value = value;
        }

        public void destroy()
        {
            Simulation.simulationGrid.Remove(this.key());
        }
    }
}