using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithmes.Models;

namespace Algorithmes.Models
{
    public class Context
    {
        public IEnumerable<IAlgoModel> Algos { get; }

        public Context()
        {
            Algos = new List<IAlgoModel>
            {
                new DijkstraModel(),
            };
        }
    }
}
