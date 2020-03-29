﻿using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SLSim
{
    internal class GenerowaniePozywienia
    {

        private SolidColorBrush ellipseBruch = new SolidColorBrush(Colors.Green);
        Random rnd = new Random();
        Pozywienie[] pozywienie;

        private int ilosc;

        private int min;
        private int max;

        private int planszaX;
        private int planszaY;

        Ellipse ellipse;
        int ellipseWidth = 10;
        int ellipseHeight = 10;
        Canvas canvas;

        /*
         * Generowanie pozywienia o stałej liczbie
         * ilosc - ilość generowanego pożywienia
         * planszaX, planszaY - wymiar planszy
         * 
         */
        public GenerowaniePozywienia(int ilosc, Canvas MyCanvas, int planszaX, int planszaY)
        {
            this.ilosc = ilosc;
            this.canvas = MyCanvas;
            this.planszaX = planszaX;
            this.planszaY = planszaY;
        }

        /*
         * Generowanie pozywienia o losowej liczbie
         * min, max - przedział z którego zostanie wylosowana ilość generowanego pożywienia
         * planszaX, planszaY - wymiar planszy
         * 
         */
        public GenerowaniePozywienia(int min, int max, Canvas MyCanvas, int planszaX, int planszaY)
        {
            this.min = min;
            this.max = max;
            this.canvas = MyCanvas;
            this.planszaX = planszaX;
            this.planszaY = planszaY;
        }

        /* Generowanie pokarmu dla stałej ilości
         * 
         */
        public void generujPozywienie()
        {
            int x;
            int y;
            pozywienie = new Pozywienie[ilosc];

            for (int i = 0; i < ilosc; i++)
            {
                x = rnd.Next(0, planszaX);
                y = rnd.Next(0, planszaY);
                pozywienie[i] = new Pozywienie(x, y);
                ellipse = new Ellipse();
                ellipse.Fill = ellipseBruch;
                ellipse.Width = ellipseWidth;
                ellipse.Height = ellipseHeight;
                Canvas.SetTop(ellipse, y);
                Canvas.SetLeft(ellipse, x);
                canvas.Children.Add(ellipse);
            }
        }

        /* Generowanie pozywienia dla lowsowej ilości
         * 
         */
        public void generujPozywienieLosowa()
        {
            ilosc = rnd.Next(min, max);

            int x;
            int y;
            pozywienie = new Pozywienie[ilosc];

            for (int i = 0; i < ilosc; i++)
            {
                x = rnd.Next(0, planszaX);
                y = rnd.Next(0, planszaY);
                pozywienie[i] = new Pozywienie(x, y);
                ellipse = new Ellipse();
                ellipse.Fill = ellipseBruch;
                ellipse.Width = ellipseWidth;
                ellipse.Height = ellipseHeight;
                Canvas.SetTop(ellipse, y);
                Canvas.SetLeft(ellipse, x);
                canvas.Children.Add(ellipse);
            }
        }


    }
}