using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
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
        Organism pom;

        Brush b;

        double mv1 = 0;
        double s1 = 0;
        double p1 = 0;
        double r1 = 0;
        int gat1 = 0;

        double mv2 = 0;
        double s2 = 0;
        double p2 = 0;
        double r2 = 0;
        int gat2 = 0;

        double mv3 = 0;
        double s3 = 0;
        double p3 = 0;
        double r3 = 0;
        int gat5 = 0;

        double mv4 = 0;
        double s4 = 0;
        double p4 = 0;
        double r4 = 0;
        int gat3 = 0;

        double mv5 = 0;
        double s5 = 0;
        double p5 = 0;
        double r5 = 0;
        int gat4 = 0;

        int ileNaPlaszy = 0;

        public stats()
        {
            InitializeComponent();

            if (Settings.numberOfSpecies == 1)
            {
                dwa.Visibility = Visibility.Hidden;
                trzy.Visibility = Visibility.Hidden;
                cztery.Visibility = Visibility.Hidden;
                piec.Visibility = Visibility.Hidden;
            }
            else if (Settings.numberOfSpecies == 2)
            {
                trzy.Visibility = Visibility.Hidden;
                cztery.Visibility = Visibility.Hidden;
                piec.Visibility = Visibility.Hidden;
            }
            else if (Settings.numberOfSpecies == 3)
            {
                cztery.Visibility = Visibility.Hidden;
                piec.Visibility = Visibility.Hidden;
            }
            else if (Settings.numberOfSpecies == 4)
            {
                piec.Visibility = Visibility.Hidden;
            }


            iloscOrganizmow.Text = Simulation.simulationGrid.Where(kpv => kpv.Value is Organism).Count().ToString();
            iloscPozywienia.Text = Simulation.simulationGrid.Where(kpv => kpv.Value is Food).Count().ToString();
            iloscGatonkowPocz.Text = Settings.numberOfSpecies.ToString();
            krokiNaTick.Text = Settings.stepsPerTic.ToString();


            foreach (KeyValuePair<int, SimObject> kvp in Simulation.simulationGrid)
            {
                if (kvp.Value is Organism)
                {
                    pom = (Organism)kvp.Value;
                    if (pom.species.Equals(Simulation.speciesList[0]))
                    {
                        gat1++;
                        mv1 += pom.maxValue;
                        s1 += pom.speed;
                        p1 += pom.ferocity;
                        r1 += pom.sightDistance;


                    }
                    if (pom.species.Equals(Simulation.speciesList[1]))
                    {
                        gat2++;
                        mv2 += pom.maxValue;
                        s2 += pom.speed;
                        p2 += pom.ferocity;
                        r2 += pom.sightDistance;
                    }
                    if (pom.species.Equals(Simulation.speciesList[2]))
                    {
                        gat3++;
                        mv3 += pom.maxValue;
                        s3 += pom.speed;
                        p3 += pom.ferocity;
                        r3 += pom.sightDistance;
                    }
                    if (pom.species.Equals(Simulation.speciesList[3]))
                    {
                        gat4++;
                        mv4 += pom.maxValue;
                        s4 += pom.speed;
                        p4 += pom.ferocity;
                        r4 += pom.sightDistance;
                    }
                    if (pom.species.Equals(Simulation.speciesList[4]))
                    {
                        gat5++;
                        mv5 += pom.maxValue;
                        s5 += pom.speed;
                        p5 += pom.ferocity;
                        r5 += pom.sightDistance;
                    }
                }
            }


            if (Settings.numberOfSpecies >= 1 )
            {
                name.Text = Simulation.speciesList[0].name;
                if (gat1 > 0)
                {
                    ileNaPlaszy++;
                    liczOs.Text = gat1.ToString();
                }
                else liczOs.Text = "Gatunek wymarły";

                if (Simulation.speciesList[0].isCarnivore)
                {
                    if (Simulation.speciesList[0].isHerbivore)
                    {
                        Odrzywianie.Text = "Wszystkożercy";
                    }
                    else
                    {
                        Odrzywianie.Text = "Mięsożercy";
                    }
                }
                else
                {
                    Odrzywianie.Text = "Roślinożercy";
                }

                Mutacja.Text = (Simulation.speciesList[0].mutationChance * 100).ToString() + "%";

                if(gat1 > 0)
                {
                    mVal.Text = Math.Round(mv1 / gat1, 2).ToString();
                    speed.Text = Math.Round(s1 / gat1, 2).ToString();
                    power.Text = Math.Round(p1 / gat1, 2).ToString();
                    range.Text = Math.Round(r1 / gat1, 2).ToString();
                }
                else
                {
                    mVal.Text = "-";
                    speed.Text = "-";
                    power.Text = "-";
                    range.Text = "-";
                }

                b = new SolidColorBrush(Simulation.speciesList[0].color);
                kolor.Fill = b;

            }
        
            if(Settings.numberOfSpecies >= 2)
            {
                name1.Text = Simulation.speciesList[1].name;
                if (gat2 > 0)
                {
                    ileNaPlaszy++;
                    liczOs1.Text = gat2.ToString();
                }
                else liczOs1.Text = "Gatunek wymarły";

                if (Simulation.speciesList[1].isCarnivore)
                {
                    if (Simulation.speciesList[1].isHerbivore)
                    {
                        Odrzywianie1.Text = "Wszystkożercy";
                    }
                    else
                    {
                        Odrzywianie1.Text = "Mięsożercy";
                    }
                }
                else
                {
                    Odrzywianie1.Text = "Roślinożercy";
                }

                Mutacja1.Text = (Simulation.speciesList[1].mutationChance * 100).ToString() + "%";
                
                if(gat2 > 0)
                {
                    mVal1.Text = Math.Round(mv2 / gat2, 2).ToString();
                    speed1.Text = Math.Round(s2 / gat2, 2).ToString();
                    power1.Text = Math.Round(p2 / gat2, 2).ToString();
                    range1.Text = Math.Round(r2 / gat2, 2).ToString();
                }
                else
                {
                    mVal1.Text = "-";
                    speed1.Text = "-";
                    power1.Text = "-";
                    range1.Text = "-";
                }

                b = new SolidColorBrush(Simulation.speciesList[1].color);
                kolor1.Fill = b;
            }

            if (Settings.numberOfSpecies >= 3)
            {
                name2.Text = Simulation.speciesList[2].name;
                if (gat3 > 0)
                {
                    ileNaPlaszy++;
                    liczOs2.Text = gat3.ToString();
                }
                else liczOs2.Text = "Gatunek wymarły";

                if (Simulation.speciesList[2].isCarnivore)
                {
                    if (Simulation.speciesList[2].isHerbivore)
                    {
                        Odrzywianie2.Text = "Wszystkożercy";
                    }
                    else
                    {
                        Odrzywianie2.Text = "Mięsożercy";
                    }
                }
                else
                {
                    Odrzywianie2.Text = "Roślinożercy";
                }

                Mutacja2.Text = (Simulation.speciesList[2].mutationChance * 100).ToString() + "%";

                if (gat3 > 0)
                {
                    mVal2.Text = Math.Round(mv3/ gat3, 2).ToString();
                    speed2.Text = Math.Round(s3 / gat3, 2).ToString();
                    power2.Text = Math.Round(p3 / gat3, 2).ToString();
                    range2.Text = Math.Round(r3 / gat3, 2).ToString();
                }
                else
                {
                    mVal2.Text = "-";
                    speed2.Text = "-";
                    power2.Text = "-";
                    range2.Text = "-";
                }


                b = new SolidColorBrush(Simulation.speciesList[2].color);
                kolor2.Fill = b;
            }

            if (Settings.numberOfSpecies >= 4)
            {
                name3.Text = Simulation.speciesList[3].name;
                if (gat4 > 0)
                {
                    ileNaPlaszy++;
                    liczOs3.Text = gat4.ToString();
                }
                else liczOs3.Text = "Gatunek wymarły";

                if (Simulation.speciesList[3].isCarnivore)
                {
                    if (Simulation.speciesList[3].isHerbivore)
                    {
                        Odrzywianie3.Text = "Wszystkożercy";
                    }
                    else
                    {
                        Odrzywianie3.Text = "Mięsożercy";
                    }
                }
                else
                {
                    Odrzywianie3.Text = "Roślinożercy";
                }

                Mutacja3.Text = (Simulation.speciesList[3].mutationChance * 100).ToString() + "%";

                if (gat4 > 0)
                {
                    mVal3.Text = Math.Round(mv4 / gat4, 2).ToString();
                    speed3.Text = Math.Round(s4 / gat4, 2).ToString();
                    power3.Text = Math.Round(p4 / gat4, 2).ToString();
                    range3.Text = Math.Round(r4 / gat4, 2).ToString();
                }
                else
                {
                    mVal3.Text = "-";
                    speed3.Text = "-";
                    power3.Text = "-";
                    range3.Text = "-";
                }


                b = new SolidColorBrush(Simulation.speciesList[3].color);
                kolor3.Fill = b;
            }


            if (Settings.numberOfSpecies == 5)
            {

                name4.Text = Simulation.speciesList[4].name;
                if (gat5 > 0)
                {
                    ileNaPlaszy++;
                    liczOs4.Text = gat5.ToString();
                }
                else liczOs4.Text = "Gatunek wymarły";

                if (Simulation.speciesList[4].isCarnivore)
                {
                    if (Simulation.speciesList[4].isHerbivore)
                    {
                        Odrzywianie4.Text = "Wszystkożercy";
                    }
                    else
                    {
                        Odrzywianie4.Text = "Mięsożercy";
                    }
                }
                else
                {
                    Odrzywianie4.Text = "Roślinożercy";
                }

                Mutacja4.Text = (Simulation.speciesList[4].mutationChance * 100).ToString() + "%";

                if (gat5 > 0)
                {
                    mVal4.Text = Math.Round(mv5 / gat5, 2).ToString();
                    speed4.Text = Math.Round(s5 / gat5, 2).ToString();
                    power4.Text = Math.Round(p5 / gat5, 2).ToString();
                    range4.Text = Math.Round(r5 / gat5, 2).ToString();
                }
                else
                {
                    mVal4.Text = "-";
                    speed4.Text = "-";
                    power4.Text = "-";
                    range4.Text = "-";
                }


                b = new SolidColorBrush(Simulation.speciesList[4].color);
                kolor4.Fill = b;
            }




            iloscGatonkowNaPlanszy.Text = ileNaPlaszy.ToString();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
