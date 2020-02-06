using Algorithmes.Algos;
using Algorithmes.Annotations;
using Algorithmes.Components;
using Algorithmes.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static Algorithmes.Algos.OptimisationPlanning;

namespace Algorithmes.Models
{
    class OptimisationPlanningModel : INotifyPropertyChanged, IAlgoModel
    {
        public ObservableCollection<Element> DataInput { get; }
        public string Name => Resources.KEY_PLANNING;

        public int Pstart { get; set; }
        public int Pend { get; set; }

        public OptimisationPlanningModel(Element[] dataInput) : base()
        {
            foreach (var l in dataInput)
                DataInput.Add(l);
        }

        public OptimisationPlanningModel()
        {
            DataInput = new ObservableCollection<Element>();
#if DEBUG
            DataInput.Add(new Element { start = 1, nb = 2 });
            DataInput.Add(new Element { start = 2, nb = 3 });
            DataInput.Add(new Element { start = 3, nb = 1 });
            DataInput.Add(new Element { start = 4, nb = 2 });
            DataInput.Add(new Element { start = 5, nb = 2 });
            DataInput.Add(new Element { start = 4, nb = 3 });
#endif
        }

        public ICommand RunHandler => new RelayCommand(Run);
        public ICommand AddHandler => new RelayCommand(Add, _ => _ is Point);

        private void Add(object obj)
        {
            if (!(obj is Element elt)) return;
            if (!DataInput.Contains(elt))
                DataInput.Add(elt);

            OnPropertyChanged(nameof(DataInput));
        }

        private void Run(object obj)
        {            
            // init
            var algo = new OptimisationPlanning(DataInput);
            algo.SearchPosibilities();

            // run process
            var strgbuilder = new StringBuilder();
            foreach (var pos in algo.posibilities)            
                strgbuilder.AppendLine($"{string.Join("; ", pos.Key.Select(e => $"{e.start}-{e.nb}"))}");
            
            MessageBox.Show(strgbuilder.ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
