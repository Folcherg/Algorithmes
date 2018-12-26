using Algorithmes.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithmes.Models
{
    public class Link : INotifyPropertyChanged, ICloneable
    {
        public int Id1 { get; set; }
        public int Id2 { get; set; }

        public Tuple<int, int> Key => Tuple.Create(Id1, Id2);       

        public int Value { get; set; }

        public Link()
        {
            Id1 = 0;
            Id2 = 0;
            Value = 0;
        }

        public Link(int id1, int id2, int val)
        {
            Id1 = id1;
            Id2 = id2;
            Value = val;            
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj) ? true : Key.Item1 == (obj as Link)?.Key.Item1 && Key.Item2 == (obj as Link)?.Key.Item2;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return new Link(Id1, Id2, Value);
        }
    }
}
