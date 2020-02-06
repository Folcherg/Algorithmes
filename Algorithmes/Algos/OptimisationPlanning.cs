using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithmes.Algos
{    
    public class OptimisationPlanning : IAlgo
    {
        public struct Element
        {
            public int start;
            public int nb;
        }

        private readonly IEnumerable<Element> Elements;
        public readonly Dictionary<IEnumerable<Element>, int> posibilities;

        public OptimisationPlanning(IEnumerable<Element> elements)
        {
            Elements = elements;
            posibilities = new Dictionary<IEnumerable<Element>, int>();
        }

        public void SearchPosibilities()
        {
            foreach (var elt in Elements)
            {
                var list = new List<Element>() { elt };
                var listtmp = SearchRecurcif(elt, Elements.Where(e => e.start >= (elt.start + elt.nb)));
                if (listtmp?.Any() == true)
                    list.AddRange(listtmp);
                if (list != null)
                    posibilities.Add(list, list.Count());
            }
        }

        private IEnumerable<Element> SearchRecurcif(Element element, IEnumerable<Element> Elementsremaining)
        {
            IEnumerable<Element> result = null;

            foreach (var elt in Elementsremaining)
            {
                var list = new List<Element>() { elt };
                var listtmp = SearchRecurcif(elt, Elementsremaining.Where(e => e.start >= (elt.start + elt.nb)));
                if(listtmp?.Any() == true)
                    list.AddRange(listtmp);

                if ((result?.Count() ?? 0) < list.Count)
                    result = list;
            }

            return result;
        }
    }
}
