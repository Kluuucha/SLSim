using System;
using System.Windows.Shapes;

namespace SLSim
{
    public class Food : SimObject
    {
        public static Food newRandomFood()
        {
            Food temp = new Food();
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
        public static void generateFood(int n)
        {
            for (int i = 0; i < n; i++)
                newRandomFood();
        }
        private Food() {}

        public Food(int x, int y)
        {
            posX = x;
            posY = y;
        }

        public void destroy()
        {
            Simulation.simulationGrid.Remove(this.key());
        }
    }
}