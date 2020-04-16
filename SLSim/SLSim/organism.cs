using System;

namespace SLSim
{
    public class Organism
    {
        int x, y;
        void fixPosition()
        {
            if (x < 0) x = 0;
            else if (x > Settings.xResolution) x = Settings.xResolution - 1;
            if (y < 0) x = 0;
            else if (y > Settings.yResolution) y = Settings.yResolution - 1;
        }
        Organism(int x, int y)
        {
            this.x = x;
            this.y = y;
            fixPosition();
            ProgramData.organisms.Add(this);
        }
    }
}
