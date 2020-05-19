using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SLSim
{
	class Plansza
	{
	    private SolidColorBrush foodBruch = new SolidColorBrush(Colors.Green);
        private SolidColorBrush osobnikBruch = new SolidColorBrush(Colors.Red);
        private SolidColorBrush ramka = new SolidColorBrush(Colors.Yellow);

        

        Ellipse ellipse;
        Rectangle rectangle;

        /*zrobiłem to na canvasie bo wydało się to proste
         * jak ma być inaczej to dajcie znać
         * a na razie do testowania waszych roziązań i tak się nada*/
        Canvas canvas;

		public Plansza(Canvas canvas) { 
           this.canvas = canvas;

        }

        public void rysujPlansze(Dictionary<int, SimObject> simulationGrid){

            rysuhRamke();

            foreach (KeyValuePair<int,SimObject> kvp in simulationGrid){
                if(kvp.Value is Organism){
                    rectangle = new Rectangle();
                    rectangle.Fill = osobnikBruch;
                    rectangle.Width = Settings.elementSize;
                    rectangle.Height = Settings.elementSize;
                    Canvas.SetTop(rectangle, (kvp.Value.posY)* Settings.elementSize);
                    Canvas.SetLeft(rectangle, (kvp.Value.posX)* Settings.elementSize);
                    canvas.Children.Add(rectangle);
                }
                else if (kvp.Value is Food){
                    ellipse = new Ellipse();
                    ellipse.Fill = foodBruch;
                    ellipse.Width = Settings.elementSize;
                    ellipse.Height = Settings.elementSize;
                    Canvas.SetTop(ellipse, (kvp.Value.posY)* Settings.elementSize);
                    Canvas.SetLeft(ellipse, (kvp.Value.posX)* Settings.elementSize);
                    canvas.Children.Add(ellipse);
                }
            }
        }

        public void rysuhRamke()
        {
            Line myLine = new Line();
            myLine.Stroke = ramka;
            myLine.X1 = 0;
            myLine.X2 = 0;
            myLine.Y1 = 0;
            myLine.Y2 = Settings.yResolution * Settings.elementSize + Settings.elementSize;
            myLine.StrokeThickness = 3;
            canvas.Children.Add(myLine);

            myLine = new Line();
            myLine.Stroke = ramka;
            myLine.X1 = 0;
            myLine.X2 = Settings.xResolution * Settings.elementSize + Settings.elementSize;
            myLine.Y1 = 0;
            myLine.Y2 = 0;
            myLine.StrokeThickness = 3;
            canvas.Children.Add(myLine);

            myLine = new Line();
            myLine.Stroke = ramka;
            myLine.X1 = Settings.xResolution * Settings.elementSize + Settings.elementSize;
            myLine.X2 = Settings.xResolution * Settings.elementSize + Settings.elementSize;
            myLine.Y1 = 0;
            myLine.Y2 = Settings.yResolution * Settings.elementSize + Settings.elementSize;
            myLine.StrokeThickness = 3;
            canvas.Children.Add(myLine);

            myLine = new Line();
            myLine.Stroke = ramka;
            myLine.X1 = 0;
            myLine.X2 = Settings.xResolution * Settings.elementSize  + Settings.elementSize;
            myLine.Y1 = Settings.yResolution * Settings.elementSize + Settings.elementSize;
            myLine.Y2 = Settings.yResolution * Settings.elementSize + Settings.elementSize;
            myLine.StrokeThickness = 3;
            canvas.Children.Add(myLine);
        }

        public void czyscPlansze(){
            canvas.Children.Clear();
        }
    }
	
}
