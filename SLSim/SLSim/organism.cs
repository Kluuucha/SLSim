using System;
using System.Collections.Generic;
using System.Threading;

namespace SLSim
{
    public class Organism : SimObject
    {
        private int sightDistance, currValue, maxValue;
        public int speed { get; private set; }
        private double ferocity;
        enum Directions { up, down, left, right, no};

        public static Organism newRandomOrganism(int sight = 7, double fer = 1, int maxvalue = 50, int speed = 3, int currvalue=25)
        {
            Organism temp = new Organism(sight,fer,maxvalue,speed,currvalue);
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
        public static void generateOrganisms()
        {
            for (int i = 0; i < Settings.organismNumber; i++)
                newRandomOrganism();
        }

        private Organism(int sight, double fer, int maxvalue, int speed, int currvalue)
        {
            sightDistance = sight;
            ferocity = fer;
            maxValue = maxvalue;
            currValue = currvalue;
            this.speed = speed;
        }
        private void mutate() {
            int mutate = Simulation.random.Next(100);
            if (Simulation.mutationChance > mutate) {
                sightDistance += Simulation.random.Next(-1, 1);
                if (sightDistance == 0) sightDistance = 1;
            }
            mutate = Simulation.random.Next(100);
            if (Simulation.mutationChance > mutate)
            {
                speed += Simulation.random.Next(-1, 1);
                if (speed == 0) speed = 1;
            }
            maxValue += Simulation.random.Next(-5, 5);
            if (maxValue < 10) maxValue = 10;
            ferocity += (Simulation.random.NextDouble()-0.5)*0.1;
            if (ferocity < 0.1) ferocity = 0.1;
        }

       public Organism(int x, int y)
        {
            posX = x;
            posY = y;
            fixPosition();
            Simulation.simulationGrid.Add(this.key(), this);
        }

        private void hunger() {
            int hunger = (int)(currValue * 0.01 * (ferocity + (0.5 * speed * speed + speed) + sightDistance * 0.5));
            if (hunger < 1) hunger = 1;
            currValue -= hunger;
            if (currValue * 10 < maxValue) {
                die();
                if (Simulation.enclosedSystem)
                {
                    Simulation.deficit += currValue;
                }
            }
            else if (Simulation.enclosedSystem)
            {
                Simulation.deficit += hunger;
            }
        }
        public double strength()
        {
            return currValue * ferocity;
        }

        void randomMovement() 
        {
            Simulation.simulationGrid.Remove(this.key());

            if(Simulation.random.Next(0, 1)==0)
                posX += (Simulation.random.Next(1, 2) * 2) - 3;
            else
                posY += (Simulation.random.Next(1, 2) * 2) - 3;
            fixPosition();

            Simulation.simulationGrid.Add(this.key(), this);
        }
        public void act()
        {
            for(int i = 0; i < speed; i++) {
                Tuple<int, int> interest = getInterest();
                if (!(interest == null))
                {
                    target_movement(interest);
                }
                else
                    random_movement();
            }
            hunger();
                
        }

        public void eat(Food food)
        {
            var foodX = food.posX;
            var foodY = food.posY;

            food.destroy();
            move(foodX, foodY);
            Food.newRandomFood();
            multiply();
        }

        public void multiply()
        {
            for (var i = -1; i < 2; i += 1)
            {
                for (var j = -1; j < 2; j += 1)
                {
                    Tuple<int, int> fixedPosition = fixValues(posX + i, posY + j);
                    if (!Simulation.simulationGrid.ContainsKey(encode(fixedPosition.Item1, fixedPosition.Item2)))
                    {
                        Organism o = new Organism(fixedPosition.Item1, fixedPosition.Item2);
                        return;
                    }  
                }
            }
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

        Tuple <int, int> fixValues(int valueX, int valueY)
        {
            var outX = valueX;
            var outY = valueY;

            if (outX < 0) outX = 0;
            else if (outX >= Settings.xResolution) outX = Settings.xResolution - 1;
            if (outY < 0) outY = 0;
            else if (outY >= Settings.yResolution) outY = Settings.yResolution - 1;
            return Tuple.Create(outX, outY);
        }

        public Tuple<int, int> getInterest() {

            for (var x = 1; x < sightDistance; x++) {
                for (var y = 0; y <= x; y++) {

                    for (var i = -1; i < 2; i += 2){
                        for (var j = -1; j < 2; j += 2){

                            if (Simulation.simulationGrid.ContainsKey(encode(posX + (x - y) * i, posY + y * j)) && checkInterest(Simulation.simulationGrid[encode(posX + (x - y) * i, posY + y * j)]))
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

        void target_movement(Tuple<int, int> interest)
        {
            var pointX = interest.Item1;
            var pointY = interest.Item2;

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
        }

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

        private void random_movement()
        {
            double randomDouble;
            randomDouble = Simulation.random.NextDouble();

            if (randomDouble < 0.25)
            {
                move_in_a_direction(Directions.down);
            }
            else if (randomDouble < 0.50)
            {
                move_in_a_direction(Directions.left);
            }
            else if (randomDouble < 0.75)
            {
                move_in_a_direction(Directions.right);
            }
            else
            {
                move_in_a_direction(Directions.up);
            }
        }

        private void move_in_a_direction(Directions direction)
        {
            var currentX = posX;
            var currentY = posY;

            if (direction == Directions.left && currentX > 0)
            {
                currentX--;
            }
            else if (direction == Directions.right && currentX < Settings.xResolution - 1)
            {
                currentX++;
            }
            else if (direction == Directions.up && currentY > 0)
            {
                currentY--;
            }
            else if (direction == Directions.down && currentY < Settings.yResolution)
            {
                currentY++;
            }

            if (Simulation.simulationGrid.ContainsKey(encode(currentX, currentY)))
            {
                if (Simulation.simulationGrid[encode(currentX, currentY)] is Food)
                {
                    eat((Food)Simulation.simulationGrid[encode(currentX, currentY)]);
                }  
            }

            else
            {
                move(currentX, currentY);
            }
        }

        private void move(int currentX, int currentY)
        {
            Simulation.simulationGrid.Remove(this.key());
            posX = currentX;
            posY = currentY;
            Simulation.simulationGrid.Add(this.key(), this);
        }
    }
}
