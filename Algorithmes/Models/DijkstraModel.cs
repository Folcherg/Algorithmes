using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Algorithmes.Algos;
using Algorithmes.Annotations;
using Algorithmes.Components;
using Algorithmes.Properties;

namespace Algorithmes.Models
{
    public class DijkstraModel : INotifyPropertyChanged, IAlgoModel
    {                
        public ObservableCollection<Link> DataInput { get; }
        public string Name => Resources.KEY_DIJKSTRA;

        public int Pstart { get; set; }
        public int Pend { get; set; }

        public DijkstraModel(Link[] dataInput) : base()
        {
            foreach(var l in dataInput)
                DataInput.Add(l);
        }

        public DijkstraModel()
        {
            DataInput = new ObservableCollection<Link>();
#if DEBUG
            DataInput.Add(new Link(0, 1, 85));
            DataInput.Add(new Link(0, 2, 217));
            DataInput.Add(new Link(0, 4, 173));
            DataInput.Add(new Link(1, 5, 80));
            DataInput.Add(new Link(2, 6, 186));
            DataInput.Add(new Link(2, 7, 103));
            DataInput.Add(new Link(7, 3, 183));
            DataInput.Add(new Link(5, 8, 250));
            DataInput.Add(new Link(8, 9, 84));
            DataInput.Add(new Link(7, 9, 167));
            DataInput.Add(new Link(4, 9, 502));            
#endif
        }

        public ICommand RunHandler => new RelayCommand(Run);
        public ICommand AddHandler => new RelayCommand(Add, _ => _ is Link);

        private void Add(object obj)
        {
            var link = obj as Link;
            if (!DataInput.Contains(link))
                DataInput.Add(link.Clone() as Link);

            OnPropertyChanged(nameof(DataInput));            
        }

        private void Run(object obj)
        {
            var dic = new Dictionary<Tuple<int, int>, int>();
            foreach (var link in DataInput)            
                dic.Add(link.Key, link.Value);
            
            // init
            var algo = new AlgoDijkstra(dic);
            algo.MainDijkstra();

            // run process
            var result = algo.GetShortRoad(Pstart, Pend);
            MessageBox.Show($"{Pstart} {Pend} {string.Join(";",result)}");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }        
    }

    
}
