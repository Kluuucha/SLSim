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
        Rectangle rectangle;

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

        public void czyscPlansze(){
            canvas.Children.Clear();
        }
    }
	
}
