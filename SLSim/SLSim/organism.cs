using System;
using System.Collections.Generic;

namespace SLSim
{
    public class Organism : SimObject
    {
        private int sightDistance;

        public Organism()
        {
            Random random = new Random();
            posX = random.Next(0, Settings.xResolution - 1);
            posY = random.Next(0, Settings.yResolution - 1);
            Simulation.simulationGrid.Add(this.key(), this);
        }

       public Organism(int x, int y)
        {
            this.posX = x;
            this.posY = y;
            fixPosition();
            Simulation.simulationGrid.Add(this.key(), this);
        }

        void randomMovement() 
        {
            Simulation.simulationGrid.Remove(this.key());

            Random rand = new Random();
            if(rand.Next(0, 1)==0)
                posX += (rand.Next(1, 2) * 2) - 3;
            else
                posY += (rand.Next(1, 2) * 2) - 3;
            fixPosition();

            Simulation.simulationGrid.Add(this.key(), this);
        }

        void die()
        {
            Simulation.simulationGrid.Remove(this.key());
        }

        void fixPosition()
        {
            if (posX < 0) posX = 0;
            else if (posX > Settings.xResolution) posX = Settings.xResolution - 1;
            if (posY < 0) posY = 0;
            else if (posY > Settings.yResolution) posY = Settings.yResolution - 1;
        }

        public Tuple<int, int> getInterest() {

            for (int x = 1; x < sightDistance; x++) {
                for (int y = 0; y <= x; y++) {

                    for (var i = -1; i < 2; i += 2){
                        for (var j = -1; j < 2; j += 2){

                            if (checkInterest(Simulation.simulationGrid[encode(posX + (x - y) * i, posY + y * j)]))
                                return Tuple.Create(posX + (x - y) * i, posY + y * j);
                            
                        }
                    }

                }
            }
            return null;
        }

        private bool checkInterest(SimObject o) {
            return o is Food; //TODO: replace 'is Food' with check for list of interest classes
        }
        
    }
}
