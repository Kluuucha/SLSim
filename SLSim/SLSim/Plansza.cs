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
        Ellipse ellipse;
        int ellipseWidth = 10;
        int ellipseHeight = 10;
        Rectangle rectangle;
        int rectangleWidth = 10;
        int rectangleHeight = 10;

        /*zrobiłem to na canvasie bo wydało się to proste
         * jak ma być inaczej to dajcie znać
         * a na razie do testowania waszych roziązań i tak się nada*/
        Canvas canvas;

		public Plansza(Canvas canvas) { 
           this.canvas = canvas;
		}

        public void rysujPlansze(Dictionary<int, SimObject> simulationGrid){

            foreach(KeyValuePair<int,SimObject> kvp in simulationGrid){
                if(kvp.Value is Organism){
                    rectangle = new Rectangle();
                    rectangle.Fill = osobnikBruch;
                    rectangle.Width = rectangleWidth;
                    rectangle.Height = rectangleHeight;
                    Canvas.SetTop(rectangle, kvp.Value.posY);
                    Canvas.SetLeft(rectangle, kvp.Value.posX);
                    canvas.Children.Add(rectangle);
                }else if (kvp.Value is Food){
                    ellipse = new Ellipse();
                    ellipse.Fill = foodBruch;
                    ellipse.Width = ellipseWidth;
                    ellipse.Height = ellipseHeight;
                    Canvas.SetTop(ellipse, kvp.Value.posY);
                    Canvas.SetLeft(ellipse, kvp.Value.posX);
                    canvas.Children.Add(ellipse);
                }
            }
        }

        public void czyscPlansze(){
            canvas.Children.Clear();
        }
    }
	
}
