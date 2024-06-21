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
using System.Windows.Threading;

namespace Живой_не_живойй
{

    public partial class MainWindow : Window
    {
        const int a = 30;
        const int b = 30;
        Rectangle[,] kubiki = new Rectangle[a,b];
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            int[,] sifri = new int[a, b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    int n = 0;
                                                 //                                       +
                    int bbi = i - 1;              //                                   + [ ][ ][ ][ ][ ][ ]<-
                    if (bbi < 0) { bbi = a - 1; }//                                      [ ][ ][ ][ ][ ][ ]
                    int ppi = i + 1;                //                                   [ ][ ][ ][ ][ ][ ]
                    if (ppi == a) { ppi = 0; }//                                         [ ][ ][ ][ ][ ][ ]                
                    int bbj = j - 1;               //                                    [ ][ ][ ][ ][ ][ ]
                    if (bbj < 0) { bbj = b - 1; }//                                      [ ][ ][ ][ ][ ][ ]
                    int ppj = j + 1;              //                                      ^   
                    if (ppj == a) { ppj = 0; } //                                         | 

                    if (kubiki[bbi, bbj].Fill == Brushes.Blue) { n++; }
                    if (kubiki[bbi, j].Fill == Brushes.Blue) { n++; }
                    //=============
                    if (kubiki[bbi, ppj].Fill == Brushes.Blue) { n++; }
                    if (kubiki[i, bbj].Fill == Brushes.Blue) { n++; }
                    //==============
                    if (kubiki[i, ppj].Fill == Brushes.Blue) { n++; }
                    if (kubiki[ppi, bbj].Fill == Brushes.Blue) { n++; }
                    //===============
                    if (kubiki[ppi, j].Fill == Brushes.Blue) { n++; }
                    if (kubiki[ppi, ppj].Fill == Brushes.Blue) { n++; }
                    
                    sifri[i, j] = n;
                }
            }
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (kubiki[i, j].Fill == Brushes.White)
                    {
                        if(sifri[i, j] == 3)
                        {
                            kubiki[i, j].Fill = Brushes.Blue;
                        }
                    }
                    if (kubiki[i, j].Fill == Brushes.Blue)
                    {
                        if (sifri[i, j] == 2 || sifri[i, j] == 3)
                        {
                            kubiki[i, j].Fill = Brushes.Blue;
                        }
                        else
                        {
                            kubiki[i, j].Fill = Brushes.White;
                        }
                    }

                    /*
                    if (sifri[i, j] < 2 || sifri[i, j] > 3)
                    {
                        kubiki[i, j].Fill = Brushes.White;
                    }
                    else if (sifri[i, j] == 3)
                    {
                        kubiki[i, j].Fill = Brushes.Blue;
                    }
                    */
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random nn = new Random();
            for ( int i = 0; i < a; i++)
            {
                for ( int j = 0; j < b; j++)
                {
                    Rectangle onekubik = new Rectangle();
                    onekubik.Width = 10;
                    onekubik.Height = 10; 
                    onekubik.Fill = (nn.Next(0, 2) == 1) ? Brushes.White : Brushes.Blue;
                    Canvass.Children.Add(onekubik);
                    Canvas.SetLeft(onekubik, j * 12);
                    Canvas.SetTop(onekubik, i * 12);

                    kubiki[i,j] = onekubik;
                }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
}
