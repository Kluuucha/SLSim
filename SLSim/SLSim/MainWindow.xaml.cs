using System;
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
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GenerowaniePozywienia generowaniePozywienia;
        public MainWindow()
        {
            InitializeComponent();

            /* commit - pozywienie v1:
             *  - na razie generowane tylko raz - trzeba dodać następne wywołania co określoną ilość czasu
             *  - na razie podane wartości rozmiaru mapy i ilości na sztywno
             *  
             */
            generowaniePozywienia = new GenerowaniePozywienia(10, MyCanvas, 980, 460);
            generowaniePozywienia.generujPozywienie();
            /*GenerowaniePozywienia generowaniePozywienia = new GenerowaniePozywienia(5,10, MyCanvas, 980, 460);
            generowaniePozywienia.generujPozywienieLosowa();*/

        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            Random rnd = new Random();
            // This is the key down event linked to the canvas
            if (e.Key == Key.Down && Canvas.GetTop(rec1) + rec1.Height < 460)
            {
                // in this if statement we are checking if the down key is pressed
                // AND the rec1 objects top plus the height is less than 420 pixels
                Canvas.SetTop(rec1, Canvas.GetTop(rec1) + 10);
                generowaniePozywienia.zjedzone(Canvas.GetLeft(rec1)+5, Canvas.GetTop(rec1)+5);
                // if these conditions match then we move the object down 10 pixels
            }
            else if (e.Key == Key.Up && Canvas.GetTop(rec1) > 0)
            {
                // in this if statement we are checking if they up key is pressed
                // and rec1s top is greater than 10 pixels
                Canvas.SetTop(rec1, Canvas.GetTop(rec1) - 10);
                generowaniePozywienia.zjedzone(Canvas.GetLeft(rec1)+5, Canvas.GetTop(rec1)+5);
                // if these conditions are met then we move the object up 10 pixels
            }
            else if (e.Key == Key.Left && Canvas.GetLeft(rec1) > 0)
            {
                // in this if statement we are checking if they left key is pressed
                // and rec1s left is greater than 0 pixels
                Canvas.SetLeft(rec1, Canvas.GetLeft(rec1) - 10);
                generowaniePozywienia.zjedzone(Canvas.GetLeft(rec1)+5, Canvas.GetTop(rec1)+5);
                // if these conditions are met then we move the object left 10 pixels
            }
            else if (e.Key == Key.Right && Canvas.GetLeft(rec1) + rec1.Width < 980)
            {
                // in this if statement we are checking if the right key is pressed
                // and rec1s right and rec1s width is less than 790 pixels
                Canvas.SetLeft(rec1, Canvas.GetLeft(rec1) + 10);
                generowaniePozywienia.zjedzone(Canvas.GetLeft(rec1)+5, Canvas.GetTop(rec1)+5);
                // if these conditions are met then we move the object 10 pixels to the right
            }
            /*
            
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
            }*/
        }
    }
}
