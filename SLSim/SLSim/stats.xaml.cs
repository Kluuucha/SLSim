using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SLSim
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class stats: Window
    {
        public stats()
        {
            InitializeComponent();
            int iorg = Simulation.simulationGrid.Where(kpv => kpv.Value is Organism).Count();
            org.Text = iorg.ToString();
            int ifd = Simulation.simulationGrid.Where(kpv => kpv.Value is Food).Count();
            fd.Text = ifd.ToString();

            fd_Copy.Text = Settings.breedingChance.ToString();
            fd_Copy1.Text = Settings.stepsPerTic.ToString();
            fd_Copy2.Text = Settings.elementSize.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
