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
using Algorithmes.Algos;

namespace Algorithmes
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AlgoDijkstra _algo;

        public MainWindow()
        {
            InitializeComponent();

            var dic = new Dictionary<Tuple<int, int>, int>
            {
                { Tuple.Create(0,1), 85 },
                { Tuple.Create(0,2), 217 },
                { Tuple.Create(0,4), 173 },
                { Tuple.Create(1,5), 80 },
                { Tuple.Create(2,6), 186 },
                { Tuple.Create(2,7), 103 },
                { Tuple.Create(7,3), 183 },
                { Tuple.Create(5,8), 250 },
                { Tuple.Create(8,9), 84 },
                { Tuple.Create(7,9), 167 },
                { Tuple.Create(4,9), 502 },
            };

            _algo = new AlgoDijkstra(dic);

            _algo.MainDijkstra();

           
        }

        /*private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var result = _algo.GetShortRoad(int.Parse(TBStart.Text), int.Parse(TBEnd.Text));
            ListView.Items.Add(string.Join(";", result));
        }*/
    }
}
