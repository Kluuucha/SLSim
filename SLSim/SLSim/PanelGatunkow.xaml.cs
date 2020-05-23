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
using System.Windows.Shapes;

namespace SLSim
{
    /// <summary>
    /// Logika interakcji dla klasy PanelGatunkow.xaml
    /// </summary>
    /// 
    class listakolorow : System.Collections.ObjectModel.ObservableCollection<ComboBoxItem>
    {
        public listakolorow()
        { 
            ComboBoxItem ComboBoxItem = new ComboBoxItem();
            ComboBoxItem.Content = "Zielony";
            Add(ComboBoxItem);
            ComboBoxItem = new ComboBoxItem();
            ComboBoxItem.Content = "Czerwony";
            Add(ComboBoxItem);
            ComboBoxItem = new ComboBoxItem();
            ComboBoxItem.Content = "Niebieski";
            Add(ComboBoxItem);
            ComboBoxItem = new ComboBoxItem();
            ComboBoxItem.Content = "Pomarańczowy";
            Add(ComboBoxItem);
            ComboBoxItem = new ComboBoxItem();
            ComboBoxItem.Content = "Fioletowy";
            Add(ComboBoxItem);
            ComboBoxItem = new ComboBoxItem();
            ComboBoxItem.Content = "Czarny";
            Add(ComboBoxItem);

        }
    }
    public partial class PanelGatunkow : Window
    {
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

        bool[ , ] kolory = new bool[Settings.numberOfSpecies,6];


        public PanelGatunkow()
        {
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
                if (Simulation.speciesList[0].color == Colors.DarkGreen) kolor.SelectedIndex = 0;
                else if (Simulation.speciesList[0].color == Colors.Red) kolor.SelectedIndex = 1;
                else if (Simulation.speciesList[0].color == Colors.Blue) kolor.SelectedIndex = 2;
                else if (Simulation.speciesList[0].color == Colors.Orange) kolor.SelectedIndex = 3;
                else if(Simulation.speciesList[0].color == Colors.Violet) kolor.SelectedIndex = 4;
                else kolor.SelectedIndex = 5;
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
                if (Simulation.speciesList[1].color == Colors.DarkGreen) kolor1.SelectedIndex = 0;
                else if (Simulation.speciesList[1].color == Colors.Red) kolor1.SelectedIndex = 1;
                else if (Simulation.speciesList[1].color == Colors.Blue) kolor1.SelectedIndex = 2;
                else if (Simulation.speciesList[1].color == Colors.Orange) kolor1.SelectedIndex = 3;
                else if (Simulation.speciesList[1].color == Colors.Violet) kolor1.SelectedIndex = 4;
                else kolor1.SelectedIndex = 5;
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
                if (Simulation.speciesList[2].color == Colors.DarkGreen) kolor2.SelectedIndex = 0;
                else if (Simulation.speciesList[2].color == Colors.Red) kolor2.SelectedIndex = 1;
                else if (Simulation.speciesList[2].color == Colors.Blue) kolor2.SelectedIndex = 2;
                else if (Simulation.speciesList[2].color == Colors.Orange) kolor2.SelectedIndex = 3;
                else if (Simulation.speciesList[2].color == Colors.Violet) kolor2.SelectedIndex = 4;
                else kolor2.SelectedIndex = 5;
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
                if (Simulation.speciesList[3].color == Colors.DarkGreen) kolor3.SelectedIndex = 0;
                else if (Simulation.speciesList[3].color == Colors.Red) kolor3.SelectedIndex = 1;
                else if (Simulation.speciesList[3].color == Colors.Blue) kolor3.SelectedIndex = 2;
                else if (Simulation.speciesList[3].color == Colors.Orange) kolor3.SelectedIndex = 3;
                else if (Simulation.speciesList[3].color == Colors.Violet) kolor3.SelectedIndex = 4;
                else kolor3.SelectedIndex = 5;
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
                if (Simulation.speciesList[4].color == Colors.DarkGreen) kolor4.SelectedIndex = 0;
                else if (Simulation.speciesList[4].color == Colors.Red) kolor4.SelectedIndex = 1;
                else if (Simulation.speciesList[4].color == Colors.Blue) kolor4.SelectedIndex = 2;
                else if (Simulation.speciesList[4].color == Colors.Orange) kolor4.SelectedIndex = 3;
                else if (Simulation.speciesList[4].color == Colors.Violet) kolor4.SelectedIndex = 4;
                else kolor4.SelectedIndex = 5;
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
               // Simulation.speciesList[0].color = c;
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
                //Simulation.speciesList[1].color = c1;
            }
            if (Settings.numberOfSpecies >= 3)
            {
                Simulation.speciesList[2].mutationChance = szansaNamutacje1;
                Simulation.speciesList[2].name = name2.Text;
                Simulation.speciesList[2].power = int.Parse(pow2.Text);
                Simulation.speciesList[2].seeRange = int.Parse(ran2.Text);
                Simulation.speciesList[2].speed = int.Parse(speed2.Text);
                Simulation.speciesList[2].startingPopulation = int.Parse(starPop2.Text);
                Simulation.speciesList[2].maxValue = int.Parse(mVal2.Text);
                Simulation.speciesList[2].isCarnivore = miesozerca2;
                Simulation.speciesList[2].isHerbivore = roslinozerca2;
               // Simulation.speciesList[2].color = c2;
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
                //Simulation.speciesList[3].color = c3;
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
                //Simulation.speciesList[4].color = c4;
            }


            Close();

        }

        private void ros(object sender, RoutedEventArgs e)
        {
            roslinozerca = true;
            miesozerca = false;
        }

        private void wsz(object sender, RoutedEventArgs e)
        {
            roslinozerca = true;
            miesozerca = true;
        }

        private void mie(object sender, RoutedEventArgs e)
        {
            roslinozerca = false;
            miesozerca = true;
        }
        private void ros1(object sender, RoutedEventArgs e)
        {
            roslinozerca1 = true;
            miesozerca1 = false;
        }

        private void wsz1(object sender, RoutedEventArgs e)
        {
            roslinozerca1 = true;
            miesozerca1 = true;
        }

        private void mie1(object sender, RoutedEventArgs e)
        {
            roslinozerca1 = false;
            miesozerca1 = true;
        }
        private void ros2(object sender, RoutedEventArgs e)
        {
            roslinozerca2 = true;
            miesozerca2 = false;
        }

        private void wsz2(object sender, RoutedEventArgs e)
        {
            roslinozerca2 = true;
            miesozerca2 = true;
        }

        private void mie2(object sender, RoutedEventArgs e)
        {
            roslinozerca2 = false;
            miesozerca2 = true;
        }
        private void ros3(object sender, RoutedEventArgs e)
        {
            roslinozerca3 = true;
            miesozerca3 = false;
        }

        private void wsz3(object sender, RoutedEventArgs e)
        {
            roslinozerca3 = true;
            miesozerca3 = true;
        }

        private void mie3(object sender, RoutedEventArgs e)
        {
            roslinozerca3 = false;
            miesozerca3 = true;
        }
        private void ros4(object sender, RoutedEventArgs e)
        {
            roslinozerca4 = true;
            miesozerca4 = false;
        }

        private void wsz4(object sender, RoutedEventArgs e)
        {
            roslinozerca4 = true;
            miesozerca4 = true;
        }

        private void mie4(object sender, RoutedEventArgs e)
        {
            roslinozerca4 = false;
            miesozerca4 = true;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           /*if(kolor.SelectedItem.Equals("Zielony"))
            {
                c = Colors.DarkGreen;

            }
            if (kolor.SelectedItem.Equals("Czerwony"))
            {
                c = Colors.Red;

            }
            if (kolor.SelectedItem.Equals("Niebieski"))
            {
                c = Colors.Blue;

            }*/

        }

    }
}
