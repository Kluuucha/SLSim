using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;


namespace SLSim
{
    public class RuchOrganizmu
    {


        Random random = new Random();

        private int movementDirection = 5;
        private int height;
        private int width;

        public RuchOrganizmu(int height, int width)
        {

            this.height = height;
            this.width = width;

        }


        public void run(Rectangle rec1)
        {


            random_movement(rec1);

        }


        public void run(KeyEventArgs e, Rectangle rec1)
        {

            if (e.Key == Key.Down && Canvas.GetTop(rec1) + rec1.Height < height)
            {
                Canvas.SetTop(rec1, Canvas.GetTop(rec1) + 10);
            }
            else if (e.Key == Key.Up && Canvas.GetTop(rec1) > 0)
            {
                Canvas.SetTop(rec1, Canvas.GetTop(rec1) - 10);
            }
            else if (e.Key == Key.Left && Canvas.GetLeft(rec1) > 0)
            {
                Canvas.SetLeft(rec1, Canvas.GetLeft(rec1) - 10);
            }
            else if (e.Key == Key.Right && Canvas.GetLeft(rec1) + rec1.Width < width)
            {
                Canvas.SetLeft(rec1, Canvas.GetLeft(rec1) + 10);
            }
            else if (e.Key == Key.Space)
            {
                run(rec1);
            }
            /*
            Random rnd = new Random();
            while (true)
            {
                int i = rnd.Next(0, 4);
                Console.WriteLine(i);
                if (i == 0 && Canvas.GetTop(rec1) + rec1.Height < 460)
                {
                    // in this if statement we are checking if the down key is pressed
                    // AND the rec1 objects top plus the height is less than 420 pixels
                    Canvas.SetTop(rec1, Canvas.GetTop(rec1) + 10);
                    // if these conditions match then we move the object down 10 pixels
                }
                else if (i == 1 && Canvas.GetTop(rec1) > 0)
                {
                    // in this if statement we are checking if they up key is pressed
                    // and rec1s top is greater than 10 pixels
                    Canvas.SetTop(rec1, Canvas.GetTop(rec1) - 10);
                    // if these conditions are met then we move the object up 10 pixels
                }
                else if (i == 2 && Canvas.GetLeft(rec1) > 0)
                {
                    // in this if statement we are checking if they left key is pressed
                    // and rec1s left is greater than 0 pixels
                    Canvas.SetLeft(rec1, Canvas.GetLeft(rec1) - 10);
                    // if these conditions are met then we move the object left 10 pixels
                }
                else if (i == 3 && Canvas.GetLeft(rec1) + rec1.Width < 980)
                {
                    // in this if statement we are checking if the right key is pressed
                    // and rec1s right and rec1s width is less than 790 pixels
                    Canvas.SetLeft(rec1, Canvas.GetLeft(rec1) + 10);
                    // if these conditions are met then we move the object 10 pixels to the right
                }
                Thread.Sleep(100);
            }
            */

        }



        private void random_movement(Rectangle rec1)
        {
            double randomDouble;
            randomDouble = random.NextDouble();
            if (movementDirection == 2)
            {
                if (randomDouble < 0.75)
                {
                    move_down(rec1);
                }
                else if (randomDouble < 0.85)
                {
                    move_left(rec1);
                }
                else if (randomDouble < 0.95)
                {
                    move_right(rec1);
                }
                else
                {
                    move_up(rec1);
                }
            }
            else if (movementDirection == 8)
            {
                if (randomDouble < 0.75)
                {
                    move_up(rec1);
                }
                else if (randomDouble < 0.85)
                {
                    move_left(rec1);
                }
                else if (randomDouble < 0.95)
                {
                    move_right(rec1);
                }
                else
                {
                    move_down(rec1);
                }
            }
            else if (movementDirection == 4)
            {
                if (randomDouble < 0.75)
                {
                    move_left(rec1);
                }
                else if (randomDouble < 0.85)
                {
                    move_up(rec1);
                }
                else if (randomDouble < 0.95)
                {
                    move_down(rec1);
                }
                else
                {
                    move_right(rec1);
                }
            }
            else if (movementDirection == 6)
            {
                if (randomDouble < 0.75)
                {
                    move_right(rec1);
                }
                else if (randomDouble < 0.85)
                {
                    move_up(rec1);
                }
                else if (randomDouble < 0.95)
                {
                    move_down(rec1);
                }
                else
                {
                    move_left(rec1);
                }
            }
            else
            {
                if (randomDouble < 0.25)
                {
                    move_up(rec1);
                }
                else if (randomDouble < 0.5)
                {
                    move_down(rec1);
                }
                else if (randomDouble < 0.75)
                {
                    move_left(rec1);
                }
                else
                {
                    move_right(rec1);
                }
            }


        }





        private bool move_left(Rectangle rec1)
        {
            bool accomplished = false;
            if (Canvas.GetLeft(rec1) > 0)
            {
                Canvas.SetLeft(rec1, Canvas.GetLeft(rec1) - 10);
                accomplished = true;
                movementDirection = 4;
            }
            else
            {
                movementDirection = 6;
            }
            return accomplished;
        }

        private bool move_right(Rectangle rec1)
        {
            bool accomplished = false;
            if (Canvas.GetLeft(rec1) + rec1.Width < width)
            {
                Canvas.SetLeft(rec1, Canvas.GetLeft(rec1) + 10);
                accomplished = true;
                movementDirection = 6;
            }
            else
            {
                movementDirection = 4;
            }
            return accomplished;
        }

        private bool move_up(Rectangle rec1)
        {
            bool accomplished = false;
            if (Canvas.GetTop(rec1) > 0)
            {
                Canvas.SetTop(rec1, Canvas.GetTop(rec1) - 10);
                accomplished = true;
                movementDirection = 8;
            }
            else
            {
                movementDirection = 2;
            }
            return accomplished;
        }

        private bool move_down(Rectangle rec1)
        {
            bool accomplished = false;
            if (Canvas.GetTop(rec1) + rec1.Height < height)
            {
                Canvas.SetTop(rec1, Canvas.GetTop(rec1) + 10);
                accomplished = true;
                movementDirection = 2;
            }
            else
            {
                movementDirection = 8;
            }
            return accomplished;
        }

        // zależy czy potrzebujemy, żeby się ruszały po diagonali

        private void move_up_right(Rectangle rec1)
        {
            move_up(rec1);
            move_right(rec1);
        }

        private void move_up_left(Rectangle rec1)
        {
            move_up(rec1);
            move_left(rec1);
        }

        private void move_down_right(Rectangle rec1)
        {
            move_down(rec1);
            move_right(rec1);
        }

        private void move_down_left(Rectangle rec1)
        {
            move_down(rec1);
            move_left(rec1);
        }


    }
}
