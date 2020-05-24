using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
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
    /// Logika interakcji dla klasy PanelGatunkow.xaml
    /// </summary>

    public partial class PanelGatunkow : Window
    {
        int[] tabKolorow = new int[5];

        double szansaNamutacje;
        bool miesozerca = false;
        bool roslinozerca = true;
        Color c;

        double szansaNamutacje1;
        bool miesozerca1 = false;
        bool roslinozerca1 = true;
        Color c1;

        double szansaNamutacje2;
        bool miesozerca2 = false;
        bool roslinozerca2 = true;
        Color c2;

        double szansaNamutacje3;
        bool miesozerca3 = false;
        bool roslinozerca3 = true;
        Color c3;

        double szansaNamutacje4;
        bool miesozerca4 = false;
        bool roslinozerca4 = true;
        Color c4;



        public PanelGatunkow()
        {
            for(int i = 0; i < 5; i++)
            {
                tabKolorow[i] = -1; 
            }

            InitializeComponent();
            if(Settings.numberOfSpecies == 1)
            {
                dwa.Visibility = Visibility.Hidden;
                trzy.Visibility = Visibility.Hidden;
                cztery.Visibility = Visibility.Hidden;
                piec.Visibility = Visibility.Hidden;
            }
            else if(Settings.numberOfSpecies == 2)
            {
                trzy.Visibility = Visibility.Hidden;
                cztery.Visibility = Visibility.Hidden;
                piec.Visibility = Visibility.Hidden;
            }
            else if(Settings.numberOfSpecies == 3)
            {
                cztery.Visibility = Visibility.Hidden;
                piec.Visibility = Visibility.Hidden;
            }
            else if(Settings.numberOfSpecies == 4)
            {
                piec.Visibility = Visibility.Hidden;
            }

            if(Settings.numberOfSpecies >= 1)
            {
                name.Text = Simulation.speciesList[0].name.ToString();
                starPop.Text = Simulation.speciesList[0].startingPopulation.ToString();
                if (Simulation.speciesList[0].color == Colors.White)  kolor.SelectedIndex = 0; 
                else if (Simulation.speciesList[0].color == Colors.Red)  kolor.SelectedIndex = 1; 
                else if (Simulation.speciesList[0].color == Colors.Blue)  kolor.SelectedIndex = 2; 
                else if (Simulation.speciesList[0].color == Colors.Orange)  kolor.SelectedIndex = 3; 
                else if (Simulation.speciesList[0].color == Colors.Violet) kolor.SelectedIndex = 4; 
                else  kolor.SelectedIndex = 5; 
                mVal.Text = Simulation.speciesList[0].maxValue.ToString();
                speed.Text = Simulation.speciesList[0].speed.ToString();
                pow.Text = Simulation.speciesList[0].power.ToString();
                ran.Text = Simulation.speciesList[0].seeRange.ToString();
                SzansaNaMutacjeValue.Text = (Simulation.speciesList[0].mutationChance * 100).ToString() + "%";
                szansaNaMutacjeSlider.Value = Simulation.speciesList[0].mutationChance;
                if(Simulation.speciesList[0].isCarnivore)
                {
                    if(Simulation.speciesList[0].isHerbivore)
                    {
                        roslinozerca = true;
                        miesozerca = true;
                        w.IsChecked = true;
                    }
                    else
                    {
                        roslinozerca = false;
                        miesozerca = true;
                        m.IsChecked = true;
                    }
                }
                else
                {
                    roslinozerca = true;
                    miesozerca = false;
                    r.IsChecked = true;
                }



            }
            if (Settings.numberOfSpecies >= 2)
            {
                name1.Text = Simulation.speciesList[1].name.ToString();
                starPop1.Text = Simulation.speciesList[1].startingPopulation.ToString();
                if (Simulation.speciesList[1].color == Colors.White)  kolor1.SelectedIndex = 0; 
                else if (Simulation.speciesList[1].color == Colors.Red)  kolor1.SelectedIndex = 1; 
                else if (Simulation.speciesList[1].color == Colors.Blue)  kolor1.SelectedIndex = 2; 
                else if (Simulation.speciesList[1].color == Colors.Orange) kolor1.SelectedIndex = 3; 
                else if (Simulation.speciesList[1].color == Colors.Violet)  kolor1.SelectedIndex = 4; 
                else  kolor1.SelectedIndex = 5; 
                mVal1.Text = Simulation.speciesList[1].maxValue.ToString();
                speed1.Text = Simulation.speciesList[1].speed.ToString();
                pow1.Text = Simulation.speciesList[1].power.ToString();
                ran1.Text = Simulation.speciesList[1].seeRange.ToString();
                SzansaNaMutacjeValue1.Text = (Simulation.speciesList[1].mutationChance * 100).ToString() + "%";
                szansaNaMutacjeSlider1.Value = Simulation.speciesList[1].mutationChance;
                if (Simulation.speciesList[1].isCarnivore)
                {
                    if (Simulation.speciesList[1].isHerbivore)
                    {
                        roslinozerca1 = true;
                        miesozerca1 = true;
                        w1.IsChecked = true;
                    }
                    else
                    {
                        roslinozerca1 = false;
                        miesozerca1 = true;
                        m1.IsChecked = true;
                    }
                }
                else
                {
                    roslinozerca1 = true;
                    miesozerca1 = false;
                    r1.IsChecked = true;
                }



            }
            if (Settings.numberOfSpecies >= 3)
            {
                name2.Text = Simulation.speciesList[2].name.ToString();
                starPop2.Text = Simulation.speciesList[2].startingPopulation.ToString();
                if (Simulation.speciesList[2].color == Colors.White)  kolor2.SelectedIndex = 0;
                else if (Simulation.speciesList[2].color == Colors.Red)  kolor2.SelectedIndex = 1;
                else if (Simulation.speciesList[2].color == Colors.Blue)  kolor2.SelectedIndex = 2; 
                else if (Simulation.speciesList[2].color == Colors.Orange)  kolor2.SelectedIndex = 3; 
                else if (Simulation.speciesList[2].color == Colors.Violet) kolor2.SelectedIndex = 4;
                else  kolor2.SelectedIndex = 5; 
                mVal2.Text = Simulation.speciesList[2].maxValue.ToString();
                speed2.Text = Simulation.speciesList[2].speed.ToString();
                pow2.Text = Simulation.speciesList[2].power.ToString();
                ran2.Text = Simulation.speciesList[2].seeRange.ToString();
                SzansaNaMutacjeValue2.Text = (Simulation.speciesList[2].mutationChance * 100).ToString() + "%";
                szansaNaMutacjeSlider2.Value = Simulation.speciesList[2].mutationChance;
                if (Simulation.speciesList[2].isCarnivore)
                {
                    if (Simulation.speciesList[2].isHerbivore)
                    {
                        roslinozerca2 = true;
                        miesozerca2 = true;
                        w2.IsChecked = true;
                    }
                    else
                    {
                        roslinozerca2 = false;
                        miesozerca2 = true;
                        m2.IsChecked = true;
                    }
                }
                else
                {
                    roslinozerca2 = true;
                    miesozerca2 = false;
                    r2.IsChecked = true;
                }



            }
            if (Settings.numberOfSpecies >= 4)
            {
                name3.Text = Simulation.speciesList[3].name.ToString();
                starPop3.Text = Simulation.speciesList[3].startingPopulation.ToString();
                if (Simulation.speciesList[3].color == Colors.White)  kolor3.SelectedIndex = 0; 
                else if (Simulation.speciesList[3].color == Colors.Red)  kolor3.SelectedIndex = 1; 
                else if (Simulation.speciesList[3].color == Colors.Blue)  kolor3.SelectedIndex = 2; 
                else if (Simulation.speciesList[3].color == Colors.Orange)  kolor3.SelectedIndex = 3; 
                else if (Simulation.speciesList[3].color == Colors.Violet)  kolor3.SelectedIndex = 4; 
                else  kolor3.SelectedIndex = 5; 
                mVal3.Text = Simulation.speciesList[3].maxValue.ToString();
                speed3.Text = Simulation.speciesList[3].speed.ToString();
                pow3.Text = Simulation.speciesList[3].power.ToString();
                ran3.Text = Simulation.speciesList[3].seeRange.ToString();
                SzansaNaMutacjeValue3.Text = (Simulation.speciesList[3].mutationChance * 100).ToString() + "%";
                szansaNaMutacjeSlider3.Value = Simulation.speciesList[3].mutationChance;
                if (Simulation.speciesList[3].isCarnivore)
                {
                    if (Simulation.speciesList[3].isHerbivore)
                    {
                        roslinozerca3 = true;
                        miesozerca3 = true;
                        w3.IsChecked = true;
                    }
                    else
                    {
                        roslinozerca3 = false;
                        miesozerca3 = true;
                        m3.IsChecked = true;
                    }
                }
                else
                {
                    roslinozerca3 = true;
                    miesozerca3 = false;
                    r3.IsChecked = true;
                }



            }
            if (Settings.numberOfSpecies == 5)
            {
                name4.Text = Simulation.speciesList[4].name.ToString();
                starPop4.Text = Simulation.speciesList[4].startingPopulation.ToString();
                if (Simulation.speciesList[4].color == Colors.White)  kolor4.SelectedIndex = 0; 
                else if (Simulation.speciesList[4].color == Colors.Red)  kolor4.SelectedIndex = 1; 
                else if (Simulation.speciesList[4].color == Colors.Blue) kolor4.SelectedIndex = 2; 
                else if (Simulation.speciesList[4].color == Colors.Orange)  kolor4.SelectedIndex = 3; 
                else if (Simulation.speciesList[4].color == Colors.Violet)  kolor4.SelectedIndex = 4; 
                else  kolor4.SelectedIndex = 5; 
                mVal4.Text = Simulation.speciesList[4].maxValue.ToString();
                speed4.Text = Simulation.speciesList[4].speed.ToString();
                pow4.Text = Simulation.speciesList[4].power.ToString();
                ran4.Text = Simulation.speciesList[4].seeRange.ToString();
                SzansaNaMutacjeValue4.Text = (Simulation.speciesList[4].mutationChance * 100).ToString() + "%";
                szansaNaMutacjeSlider4.Value = Simulation.speciesList[4].mutationChance;
                if (Simulation.speciesList[4].isCarnivore)
                {
                    if (Simulation.speciesList[4].isHerbivore)
                    {
                        roslinozerca4 = true;
                        miesozerca4 = true;
                        w4.IsChecked = true;
                    }
                    else
                    {
                        roslinozerca4 = false;
                        miesozerca4 = true;
                        m4.IsChecked = true;
                    }
                }
                else
                {
                    roslinozerca4 = true;
                    miesozerca4 = false;
                    r4.IsChecked = true;
                }



            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            szansaNamutacje = Math.Round(szansaNaMutacjeSlider.Value,2);
            SzansaNaMutacjeValue.Text = (szansaNamutacje*100).ToString()+"%";
            szansaNamutacje1 = Math.Round(szansaNaMutacjeSlider1.Value, 2);
            SzansaNaMutacjeValue1.Text = (szansaNamutacje1 * 100).ToString() + "%";
            szansaNamutacje2 = Math.Round(szansaNaMutacjeSlider2.Value, 2);
            SzansaNaMutacjeValue2.Text = (szansaNamutacje2 * 100).ToString() + "%";
            szansaNamutacje3 = Math.Round(szansaNaMutacjeSlider3.Value, 2);
            SzansaNaMutacjeValue3.Text = (szansaNamutacje3 * 100).ToString() + "%";
            szansaNamutacje4 = Math.Round(szansaNaMutacjeSlider4.Value, 2);
            SzansaNaMutacjeValue4.Text = (szansaNamutacje4 * 100).ToString() + "%";
        }

        private void Zapisz(object sender, RoutedEventArgs e)
        {
            if(Settings.numberOfSpecies >= 1)
            { 
                Simulation.speciesList[0].mutationChance = szansaNamutacje;
                Simulation.speciesList[0].name = name.Text;
                Simulation.speciesList[0].power = int.Parse(pow.Text);
                Simulation.speciesList[0].seeRange = int.Parse(ran.Text);
                Simulation.speciesList[0].speed = int.Parse(speed.Text);
                Simulation.speciesList[0].startingPopulation = int.Parse(starPop.Text);
                Simulation.speciesList[0].maxValue = int.Parse(mVal.Text);
                Simulation.speciesList[0].isCarnivore = miesozerca;
                Simulation.speciesList[0].isHerbivore = roslinozerca;
                Simulation.speciesList[0].color = c;
            }
            if (Settings.numberOfSpecies >= 2)
            {
                Simulation.speciesList[1].mutationChance = szansaNamutacje1;
                Simulation.speciesList[1].name = name1.Text;
                Simulation.speciesList[1].power = int.Parse(pow1.Text);
                Simulation.speciesList[1].seeRange = int.Parse(ran1.Text);
                Simulation.speciesList[1].speed = int.Parse(speed1.Text);
                Simulation.speciesList[1].startingPopulation = int.Parse(starPop1.Text);
                Simulation.speciesList[1].maxValue = int.Parse(mVal1.Text);
                Simulation.speciesList[1].isCarnivore = miesozerca1;
                Simulation.speciesList[1].isHerbivore = roslinozerca1;
                Simulation.speciesList[1].color = c1;
            }
            if (Settings.numberOfSpecies >= 3)
            {
                Simulation.speciesList[2].mutationChance = szansaNamutacje2;
                Simulation.speciesList[2].name = name2.Text;
                Simulation.speciesList[2].power = int.Parse(pow2.Text);
                Simulation.speciesList[2].seeRange = int.Parse(ran2.Text);
                Simulation.speciesList[2].speed = int.Parse(speed2.Text);
                Simulation.speciesList[2].startingPopulation = int.Parse(starPop2.Text);
                Simulation.speciesList[2].maxValue = int.Parse(mVal2.Text);
                Simulation.speciesList[2].isCarnivore = miesozerca2;
                Simulation.speciesList[2].isHerbivore = roslinozerca2;
                Simulation.speciesList[2].color = c2;
            }
            if (Settings.numberOfSpecies >= 4)
            {
                Simulation.speciesList[3].mutationChance = szansaNamutacje3;
                Simulation.speciesList[3].name = name3.Text;
                Simulation.speciesList[3].power = int.Parse(pow3.Text);
                Simulation.speciesList[3].seeRange = int.Parse(ran3.Text);
                Simulation.speciesList[3].speed = int.Parse(speed3.Text);
                Simulation.speciesList[3].startingPopulation = int.Parse(starPop3.Text);
                Simulation.speciesList[3].maxValue = int.Parse(mVal3.Text);
                Simulation.speciesList[3].isCarnivore = miesozerca3;
                Simulation.speciesList[3].isHerbivore = roslinozerca3;
                Simulation.speciesList[3].color = c3;
            }
            if (Settings.numberOfSpecies == 5)
            {
                Simulation.speciesList[4].mutationChance = szansaNamutacje4;
                Simulation.speciesList[4].name = name4.Text;
                Simulation.speciesList[4].power = int.Parse(pow4.Text);
                Simulation.speciesList[4].seeRange = int.Parse(ran4.Text);
                Simulation.speciesList[4].speed = int.Parse(speed4.Text);
                Simulation.speciesList[4].startingPopulation = int.Parse(starPop4.Text);
                Simulation.speciesList[4].maxValue = int.Parse(mVal4.Text);
                Simulation.speciesList[4].isCarnivore = miesozerca4;
                Simulation.speciesList[4].isHerbivore = roslinozerca4;
                Simulation.speciesList[4].color = c4;
            }


            Close();

        }

        private void ros(object sender, RoutedEventArgs e)
        {
            if(sender.Equals(r))
            {
                roslinozerca = true;
                miesozerca = false;
            }
            if (sender.Equals(r1))
            {
                roslinozerca1 = true;
                miesozerca1 = false;
            }
            if (sender.Equals(r2))
            {
                roslinozerca2 = true;
                miesozerca2 = false;
            }
            if (sender.Equals(r3))
            {
                roslinozerca3 = true;
                miesozerca3 = false;
            }
            if (sender.Equals(r4))
            {
                roslinozerca4 = true;
                miesozerca4 = false;
            }


        }

        private void wsz(object sender, RoutedEventArgs e)
        {
            if(sender.Equals(w))
            {          
                roslinozerca = true;
                miesozerca = true;
            }
            if (sender.Equals(w1))
            {
                roslinozerca1 = true;
                miesozerca1 = true;
            }
            if (sender.Equals(w2))
            {
                roslinozerca2 = true;
                miesozerca2 = true;
            }
            if (sender.Equals(w3))
            {
                roslinozerca3 = true;
                miesozerca3 = true;
            }
            if (sender.Equals(4))
            {
                roslinozerca4 = true;
                miesozerca4 = true;
            }

        }

        private void mie(object sender, RoutedEventArgs e)
        {
            if(sender.Equals(m))
            {
                roslinozerca = false;
                miesozerca = true;
            }
            if (sender.Equals(m1))
            {
                roslinozerca1 = false;
                miesozerca1 = true;
            }
            if (sender.Equals(m2))
            {
                roslinozerca2 = false;
                miesozerca2 = true;
            }
            if (sender.Equals(m3))
            {
                roslinozerca3 = false;
                miesozerca3 = true;
            }
            if (sender.Equals(m4))
            {
                roslinozerca4 = false;
                miesozerca4 = true;
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (sender.Equals(kolor))
            {
                if (kolor.SelectedIndex.Equals(0)) zarezerwujBialy(0);
                if (kolor.SelectedIndex.Equals(1)) zarezerwujCzerwony(0);
                if (kolor.SelectedIndex.Equals(2)) zarezerwujNiebieski(0);
                if (kolor.SelectedIndex.Equals(3)) zarezerwujPomaranczowy(0);
                if (kolor.SelectedIndex.Equals(4)) zarezerwujFioletowy(0);
                if (kolor.SelectedIndex.Equals(5)) zarezerwujCzarny(0);
            }
            if (sender.Equals(kolor1))
            {
                if (kolor1.SelectedIndex.Equals(0)) zarezerwujBialy(1);
                if (kolor1.SelectedIndex.Equals(1)) zarezerwujCzerwony(1);
                if (kolor1.SelectedIndex.Equals(2)) zarezerwujNiebieski(1);
                if (kolor1.SelectedIndex.Equals(3)) zarezerwujPomaranczowy(1);
                if (kolor1.SelectedIndex.Equals(4)) zarezerwujFioletowy(1);
                if (kolor1.SelectedIndex.Equals(5)) zarezerwujCzarny(1);
            }

            if(sender.Equals(kolor2))
            {            
                if (kolor2.SelectedIndex.Equals(0)) zarezerwujBialy(2);
                if (kolor2.SelectedIndex.Equals(1)) zarezerwujCzerwony(2);
                if (kolor2.SelectedIndex.Equals(2)) zarezerwujNiebieski(2);
                if (kolor2.SelectedIndex.Equals(3)) zarezerwujPomaranczowy(2);
                if (kolor2.SelectedIndex.Equals(4)) zarezerwujFioletowy(2);
                if (kolor2.SelectedIndex.Equals(5)) zarezerwujCzarny(2);

            }

            if (sender.Equals(kolor3))
            {
                if (kolor3.SelectedIndex.Equals(0)) zarezerwujBialy(3);
                if (kolor3.SelectedIndex.Equals(1)) zarezerwujCzerwony(3);
                if (kolor3.SelectedIndex.Equals(2)) zarezerwujNiebieski(3);
                if (kolor3.SelectedIndex.Equals(3)) zarezerwujPomaranczowy(3);
                if (kolor3.SelectedIndex.Equals(4)) zarezerwujFioletowy(3);
                if (kolor3.SelectedIndex.Equals(5)) zarezerwujCzarny(3);

            }

            if (sender.Equals(kolor4))
            {
                if (kolor4.SelectedIndex.Equals(0)) zarezerwujBialy(4);
                if (kolor4.SelectedIndex.Equals(1)) zarezerwujCzerwony(4);
                if (kolor4.SelectedIndex.Equals(2)) zarezerwujNiebieski(4);
                if (kolor4.SelectedIndex.Equals(3)) zarezerwujPomaranczowy(4);
                if (kolor4.SelectedIndex.Equals(4)) zarezerwujFioletowy(4);
                if (kolor4.SelectedIndex.Equals(5)) zarezerwujCzarny(4);

            }

        }

        public void zarezerwujBialy(int index)
        {
            if(index == 0)
            {
                white1.IsEnabled = false;
                white2.IsEnabled = false;
                white3.IsEnabled = false;
                white4.IsEnabled = false;

                c = Colors.White;

                odblokujKolor(tabKolorow[0]);
                tabKolorow[0] = 0;
            }
            if (index == 1)
            {
                white.IsEnabled = false;
                white2.IsEnabled = false;
                white3.IsEnabled = false;
                white4.IsEnabled = false;

                c1 = Colors.White;

                odblokujKolor(tabKolorow[1]);
                tabKolorow[1] = 0;
            }
            if (index == 2)
            {
                white1.IsEnabled = false;
                white.IsEnabled = false;
                white3.IsEnabled = false;
                white4.IsEnabled = false;

                c2 = Colors.White;

                odblokujKolor(tabKolorow[2]);
                tabKolorow[2] = 0;
            }
            if (index == 3)
            {
                white1.IsEnabled = false;
                white2.IsEnabled = false;
                white.IsEnabled = false;
                white4.IsEnabled = false;

                c3 = Colors.White;

                odblokujKolor(tabKolorow[3]);
                tabKolorow[3] = 0;
            }
            if (index == 4)
            {
                white1.IsEnabled = false;
                white2.IsEnabled = false;
                white3.IsEnabled = false;
                white.IsEnabled = false;

                c4 = Colors.White;

                odblokujKolor(tabKolorow[4]);
                tabKolorow[4] = 0;
            }
        }
        public void zarezerwujCzerwony(int index)
        {
            if (index == 0)
            {
                red1.IsEnabled = false;
                red2.IsEnabled = false;
                red3.IsEnabled = false;
                red4.IsEnabled = false;

                c = Colors.Red;

                odblokujKolor(tabKolorow[0]);
                tabKolorow[0] = 1;
            }
            else if (index == 1)
            {
                red.IsEnabled = false;
                red2.IsEnabled = false;
                red3.IsEnabled = false;
                red4.IsEnabled = false;

                c1 = Colors.Red;

                odblokujKolor(tabKolorow[1]);
                tabKolorow[1] = 1;
            }
            else if (index == 2)
            {
                red1.IsEnabled = false;
                red.IsEnabled = false;
                red3.IsEnabled = false;
                red4.IsEnabled = false;

                c2 = Colors.Red;

                odblokujKolor(tabKolorow[2]);
                tabKolorow[2] = 1;
            }
            else if (index == 3)
            {
                red1.IsEnabled = false;
                red2.IsEnabled = false;
                red.IsEnabled = false;
                red4.IsEnabled = false;

                c3 = Colors.Red;

                odblokujKolor(tabKolorow[3]);
                tabKolorow[3] = 1;
            }
            else if (index == 4)
            {
                red1.IsEnabled = false;
                red2.IsEnabled = false;
                red3.IsEnabled = false;
                red.IsEnabled = false;

                c4 = Colors.White;

                odblokujKolor(tabKolorow[4]);
                tabKolorow[4] = 1;
            }
        }
        public void zarezerwujNiebieski(int index)
        {
            if (index == 0)
            {
                blue1.IsEnabled = false;
                blue2.IsEnabled = false;
                blue3.IsEnabled = false;
                blue4.IsEnabled = false;

                c = Colors.Blue;

                odblokujKolor(tabKolorow[0]);
                tabKolorow[0] = 2;
            }
            if (index == 1)
            {
                blue.IsEnabled = false;
                blue2.IsEnabled = false;
                blue3.IsEnabled = false;
                blue4.IsEnabled = false;

                c1 = Colors.Blue;

                odblokujKolor(tabKolorow[1]);
                tabKolorow[1] = 2;
            }
            if (index == 2)
            {
                blue1.IsEnabled = false;
                blue.IsEnabled = false;
                blue3.IsEnabled = false;
                blue4.IsEnabled = false;

                c2 = Colors.Blue;

                odblokujKolor(tabKolorow[2]);
                tabKolorow[2] = 2;
            }
            if (index == 3)
            {
                blue1.IsEnabled = false;
                blue2.IsEnabled = false;
                blue.IsEnabled = false;
                blue4.IsEnabled = false;

                c3 = Colors.Blue;

                odblokujKolor(tabKolorow[3]);
                tabKolorow[3] = 2;
            }
            if (index == 4)
            {
                blue1.IsEnabled = false;
                blue2.IsEnabled = false;
                blue3.IsEnabled = false;
                blue.IsEnabled = false;

                c4 = Colors.Blue;

                odblokujKolor(tabKolorow[4]);
                tabKolorow[4] = 2;
            }
        }
        public void zarezerwujPomaranczowy(int index)
        {
            if (index == 0)
            {
                orange1.IsEnabled = false;
                orange2.IsEnabled = false;
                orange3.IsEnabled = false;
                orange4.IsEnabled = false;

                c = Colors.Orange;

                odblokujKolor(tabKolorow[0]);
                tabKolorow[0] = 3;
            }
            if (index == 1)
            {
                orange.IsEnabled = false;
                orange2.IsEnabled = false;
                orange3.IsEnabled = false;
                orange4.IsEnabled = false;

                c1 = Colors.Orange;

                odblokujKolor(tabKolorow[1]);
                tabKolorow[1] = 3;
            }
            if (index == 2)
            {
                orange1.IsEnabled = false;
                orange.IsEnabled = false;
                orange3.IsEnabled = false;
                orange4.IsEnabled = false;

                c2 = Colors.Orange;

                odblokujKolor(tabKolorow[2]);
                tabKolorow[2] = 3;
            }
            if (index == 3)
            {
                orange1.IsEnabled = false;
                orange2.IsEnabled = false;
                orange.IsEnabled = false;
                orange4.IsEnabled = false;

                c3 = Colors.Orange;

                odblokujKolor(tabKolorow[3]);
                tabKolorow[3] = 3;
            }
            if (index == 4)
            {
                orange1.IsEnabled = false;
                orange2.IsEnabled = false;
                orange3.IsEnabled = false;
                orange.IsEnabled = false;

                c4 = Colors.Orange;

                odblokujKolor(tabKolorow[4]);
                tabKolorow[4] = 3;
            }
        }
        public void zarezerwujFioletowy(int index)
        {
            if (index == 0)
            {
                violet1.IsEnabled = false;
                violet2.IsEnabled = false;
                violet3.IsEnabled = false;
                violet4.IsEnabled = false;

                c = Colors.Violet;

                odblokujKolor(tabKolorow[0]);
                tabKolorow[0] = 4;
            }
            if (index == 1)
            {
                violet.IsEnabled = false;
                violet2.IsEnabled = false;
                violet3.IsEnabled = false;
                violet4.IsEnabled = false;

                c1 = Colors.Violet;

                odblokujKolor(tabKolorow[1]);
                tabKolorow[1] = 4;
            }
            if (index == 2)
            {
                violet1.IsEnabled = false;
                violet.IsEnabled = false;
                violet3.IsEnabled = false;
                violet4.IsEnabled = false;

                c2 = Colors.Violet;

                odblokujKolor(tabKolorow[2]);
                tabKolorow[2] = 4;
            }
            if (index == 3)
            {
                violet1.IsEnabled = false;
                violet2.IsEnabled = false;
                violet.IsEnabled = false;
                violet4.IsEnabled = false;

                c3 = Colors.Violet;

                odblokujKolor(tabKolorow[3]);
                tabKolorow[3] = 4;
            }
            if (index == 4)
            {
                violet1.IsEnabled = false;
                violet2.IsEnabled = false;
                violet3.IsEnabled = false;
                violet.IsEnabled = false;

                c4 = Colors.Violet;

                odblokujKolor(tabKolorow[4]);
                tabKolorow[4] = 4;
            }
        }
        public void zarezerwujCzarny(int index)
        {
            if (index == 0)
            {
                black1.IsEnabled = false;
                black2.IsEnabled = false;
                black3.IsEnabled = false;
                black4.IsEnabled = false;

                c = Colors.Black;

                odblokujKolor(tabKolorow[0]);
                tabKolorow[0] = 5;
            }
            if (index == 1)
            {
                black.IsEnabled = false;
                black2.IsEnabled = false;
                black3.IsEnabled = false;
                black4.IsEnabled = false;

                c1 = Colors.Black;

                odblokujKolor(tabKolorow[1]);
                tabKolorow[1] = 5;
            }
            if (index == 2)
            {
                black1.IsEnabled = false;
                black.IsEnabled = false;
                black3.IsEnabled = false;
                black4.IsEnabled = false;

                c2 = Colors.Black;

                odblokujKolor(tabKolorow[2]);
                tabKolorow[2] = 5;
            }
            if (index == 3)
            {
                black1.IsEnabled = false;
                black2.IsEnabled = false;
                black.IsEnabled = false;
                black4.IsEnabled = false;

                c3 = Colors.Black;

                odblokujKolor(tabKolorow[3]);
                tabKolorow[3] = 5;
            }
            if (index == 4)
            {
                black1.IsEnabled = false;
                black2.IsEnabled = false;
                black3.IsEnabled = false;
                black.IsEnabled = false;

                c4 = Colors.Black;

                odblokujKolor(tabKolorow[4]);
                tabKolorow[4] = 5;
            }
        }
        public void odblokujKolor(int index)
        {

            if(index == -1)
            { 

                return;
            }
            else if(index == 0)
            {
                white.IsEnabled = true;
                white1.IsEnabled = true;
                white2.IsEnabled = true;
                white3.IsEnabled = true;
                white4.IsEnabled = true;
            }
            else if(index == 1)
            {
                red.IsEnabled = true;
                red1.IsEnabled = true;
                red2.IsEnabled = true;
                red3.IsEnabled = true;
                red4.IsEnabled = true;
            }
            else if (index == 2)
            {
                blue.IsEnabled = true;
                blue1.IsEnabled = true;
                blue2.IsEnabled = true;
                blue3.IsEnabled = true;
                blue4.IsEnabled = true;
            }
            else if (index == 3)
            {
                orange.IsEnabled = true;
                orange1.IsEnabled = true;
                orange2.IsEnabled = true;
                orange3.IsEnabled = true;
                orange4.IsEnabled = true;
            }
            else if (index == 4)
            {
                violet.IsEnabled = true;
                violet1.IsEnabled = true;
                violet2.IsEnabled = true;
                violet3.IsEnabled = true;
                violet4.IsEnabled = true;
            }
            else if (index == 5)
            {
                black.IsEnabled = true;
                black1.IsEnabled = true;
                black2.IsEnabled = true;
                black3.IsEnabled = true;
                black4.IsEnabled = true;
            }
        }

    }
}
