using System;

namespace SLSim
{
    public class Organism
    {
        int x, y;
        int power;
        Organism()
        {
            Random random = new Random();
            x = random.Next(0, Settings.xResolution - 1);
            y = random.Next(0, Settings.yResolution - 1);
            ProgramData.organisms.
            ProgramData.organisms.Add(this);
        }
        Organism(int x, int y)
        {
            this.x = x;
            this.y = y;
            fixPosition();
            ProgramData.organisms.Add(this);
        }
        void randomMovement()
        {
            Random rand = new Random();
            x += rand.Next(-3, 3);
            y += rand.Next(-3, 3);
            fixPosition();
        }
        void die()
        {
            ProgramData.organisms.Remove(this);
        }
        void fixPosition()
        {
            if (x < 0) x = 0;
            else if (x > Settings.xResolution) x = Settings.xResolution - 1;
            if (y < 0) x = 0;
            else if (y > Settings.yResolution) y = Settings.yResolution - 1;
        }
    }
}
