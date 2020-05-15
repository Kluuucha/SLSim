using System;
using System.Collections.Generic;
using System.Threading;

namespace SLSim
{
    public class Organism : SimObject
    {
        private int sightDistance = 5;

        Random random = new Random();
        enum Directions { up, down, left, right, no};
        Directions movementDirection = Directions.no;

        public static Organism newRandomOrganism()
        {
            Random random = new Random();

            Organism temp = new Organism();
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
        public static void generateOrganisms()
        {
            for (int i = 0; i < Settings.organismNumber; i++)
                newRandomOrganism();
        }

        public Organism()
        {
            posX = random.Next(0, Settings.xResolution - 1);
            posY = random.Next(0, Settings.yResolution - 1);

        }

       public Organism(int x, int y)
        {
            this.posX = x;
            this.posY = y;
            fixPosition();
        }

        void randomMovement() 
        {
            Simulation.simulationGrid.Remove(this.key());

            if(random.Next(0, 1)==0)
                posX += (random.Next(1, 2) * 2) - 3;
            else
                posY += (random.Next(1, 2) * 2) - 3;
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
            else if (posX >= Settings.xResolution) posX = Settings.xResolution - 1;
            if (posY < 0) posY = 0;
            else if (posY >= Settings.yResolution) posY = Settings.yResolution - 1;
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



        // ruch do jakiegoś miejsca z jakąś prędkością (im mniejsza tym szybciej)

        void movement(int pointX, int pointY, int speed)
        {

            while (!(posX == pointX && posY == pointY))
            {
                if (posX < pointX)
                {
                    move_in_a_direction(Directions.right);
                }
                else if (posX > pointX)
                {
                    move_in_a_direction(Directions.left);
                }
                else if (posY < pointY)
                {
                    move_in_a_direction(Directions.down);
                }
                else if (posY > pointY)
                {
                    move_in_a_direction(Directions.up);
                }
                Thread.Sleep(speed);
            }
        }

        // losowy ruch do jakiegoś miejsca z jakąś prędkością

        void random_movement(int seconds, int speed)
        {
            int milliseconds_passed = 0;
            long time_in_milliseconds = seconds * 1000;

            while (milliseconds_passed < time_in_milliseconds)
            {
                random_movement();
                Thread.Sleep(speed);
                milliseconds_passed = milliseconds_passed + speed;
            }
        }


        // losowy ruch o 1 kratkę
        private void random_movement()
        {
            double randomDouble;
            randomDouble = random.NextDouble();
            if (movementDirection == Directions.down)
            {
                if (randomDouble < 0.75)
                {
                    move_in_a_direction(Directions.down);
                }
                else if (randomDouble < 0.85)
                {
                    move_in_a_direction(Directions.left);
                }
                else if (randomDouble < 0.95)
                {
                    move_in_a_direction(Directions.right);
                }
                else
                {
                    move_in_a_direction(Directions.up);
                }
            }
            else if (movementDirection == Directions.up)
            {
                if (randomDouble < 0.75)
                {
                    move_in_a_direction(Directions.up);
                }
                else if (randomDouble < 0.85)
                {
                    move_in_a_direction(Directions.left);
                }
                else if (randomDouble < 0.95)
                {
                    move_in_a_direction(Directions.right);
                }
                else
                {
                    move_in_a_direction(Directions.down);
                }
            }
            else if (movementDirection == Directions.left)
            {
                if (randomDouble < 0.75)
                {
                    move_in_a_direction(Directions.left);
                }
                else if (randomDouble < 0.85)
                {
                    move_in_a_direction(Directions.up);
                }
                else if (randomDouble < 0.95)
                {
                    move_in_a_direction(Directions.down);
                }
                else
                {
                    move_in_a_direction(Directions.right);
                }
            }
            else if (movementDirection == Directions.right)
            {
                if (randomDouble < 0.75)
                {
                    move_in_a_direction(Directions.right);
                }
                else if (randomDouble < 0.85)
                {
                    move_in_a_direction(Directions.up);
                }
                else if (randomDouble < 0.95)
                {
                    move_in_a_direction(Directions.down);
                }
                else
                {
                    move_in_a_direction(Directions.left);
                }
            }
            else
            {
                if (randomDouble < 0.25)
                {
                    move_in_a_direction(Directions.up);
                }
                else if (randomDouble < 0.5)
                {
                    move_in_a_direction(Directions.down);
                }
                else if (randomDouble < 0.75)
                {
                    move_in_a_direction(Directions.left);
                }
                else
                {
                    move_in_a_direction(Directions.right);
                }
            }
        }



        private void move_in_a_direction(Directions direction)
        {
            var currentX = posX;
            var currentY = posY;

            if (direction == Directions.left)
            {
                if (currentX > 0)
                {
                    currentX = currentX - 1;
                    movementDirection = Directions.left;
                }
                else
                {
                    movementDirection = Directions.right;
                }
            }
            else if (direction == Directions.right)
            {
                if (currentX < Settings.xResolution - 1)
                {
                    currentX = currentX + 1;
                    movementDirection = Directions.right;
                }
                else
                {
                    movementDirection = Directions.left;
                }
            }
            else if (direction == Directions.up)
            {
                if (currentY > 0)
                {
                    currentY = currentY - 1;
                    movementDirection = Directions.up;
                }
                else
                {
                    movementDirection = Directions.down;
                }
            }
            else if (direction == Directions.down)
            {
                if (currentY < Settings.yResolution)
                {
                    currentY = currentY + 1;
                    movementDirection = Directions.down;
                }
                else
                {
                    movementDirection = Directions.up;
                }
            }

            if (!Simulation.simulationGrid.ContainsKey(encode(currentX, currentY))) {
                Simulation.simulationGrid.Remove(this.key());
                posX = currentX;
                posY = currentY;
                Simulation.simulationGrid.Add(this.key(), this);
            } 
        }
    }
}
