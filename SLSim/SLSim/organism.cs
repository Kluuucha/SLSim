using System;

namespace SLSim
{
    public class Organism : SimObject
    {
        Organism()
        {
            Random random = new Random();
            posX = random.Next(0, Settings.xResolution - 1);
            posY = random.Next(0, Settings.yResolution - 1);
           // ProgramData.organisms.Add(this);
        }
        Organism(int x, int y)
        {
            this.posX = x;
            this.posY = y;
            fixPosition();
           // ProgramData.organisms.Add(this);
        }
        void randomMovement()
        {
            Random rand = new Random();
            posX += rand.Next(-3, 3);
            posY += rand.Next(-3, 3);
            fixPosition();
        }
        void die()
        {
           // ProgramData.organisms.Remove(this);
        }
        void fixPosition()
        {
            if (posX < 0) posX = 0;
            else if (posX >= Settings.xResolution) posX = Settings.xResolution - 1;
            if (posY < 0) posX = 0;
            else if (posY >= Settings.yResolution) posY = Settings.yResolution - 1;
        }
    }
}
