using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Algorithmes.Algos
{
    internal class AlgoDijkstra : IAlgo
    {        
        private readonly Dictionary<int, int> _distances;
        private readonly Dictionary<Tuple<int, int>, int> _poids;
        private readonly Dictionary<int, int> _prédécesseur;

        public AlgoDijkstra(Dictionary<Tuple<int, int>, int> poids)
        {
            var sommets = poids.Keys.Select(_ => _.Item1).Concat(poids.Keys.Select(_ => _.Item2)).Distinct().ToList();            
            _poids = poids;
            _distances = new Dictionary<int, int>();
            _prédécesseur = new Dictionary<int, int>();

            foreach (var s in sommets)
            {
                _distances.Add(s, -1);
                _prédécesseur.Add(s, -1);
            }           
        }

        /// <summary>
        /// initialisation de l'agorhime Dijkstra
        /// </summary>
        /// <param name="sommets"> liste des sommets</param>
        /// <param name="sdeb"> sommet de départ</param>
        internal void Initialisation(IEnumerable<int> sommets, int sdeb)
        {
            foreach (var s in sommets.ToList())            
                _distances[s] = int.MaxValue;   // on initialise les sommets autres que sdeb à infini 
            
            _distances[sdeb] = 0;    // la distance au sommet de départ sdeb est nulle 
        }

        internal int TrouverMin(IEnumerable<int> sommets)
        {
            var mini = int.MaxValue;
            var sommet = -1;
            foreach (var s in sommets)
            {
                if (_distances[s] >= mini)
                    continue;

                mini = _distances[s];
                sommet = s;
            }

            return sommet;            
        }

        internal void Update(int s1, int s2)
        {
            if (_distances[s2] > _distances[s1] + Poids(s1, s2))    // Si la distance de sdeb à s2 est plus grande que
                                                                    // celle de sdeb à S1 plus celle de S1 à S2
            {
                _distances[s2] = _distances[s1] + Poids(s1, s2);    // On prend ce nouveau chemin qui est plus court
                _prédécesseur[s2] = s1;                             // En notant par où on passe
            }            
        }

        private int Poids(int s1, int s2)
        {
            var key = Tuple.Create(s1, s2);
            if (_poids.ContainsKey(key))
                return _poids[key];

            key = Tuple.Create(s2, s1);
            if (_poids.ContainsKey(key))
                return _poids[key];
            
            return int.MaxValue;
        }

        internal void MainDijkstra()
        {
            Initialisation(_distances.Keys, _distances.Keys.First());
            var q = _distances.Keys.ToList();    // ensemble de tous les nœuds

            // tant que Q n'est pas un ensemble vide
            while (q.Any())
            {
                var s1 = TrouverMin(q);
                q.Remove(s1);   // privé Q de s1

                // mettre à jour la distance des noeuds voisin à s1
                foreach (var s2 in _poids.Keys.Where(_ => _.Item1 == s1 || _.Item2 == s1).Select(_ => _.Item1==s1?_.Item2:_.Item1))                
                    Update(s1, s2);                
            }            
        }

        internal IEnumerable<int> GetShortRoad(int start, int end)
        {
            var road = new List<int>();     // suite vide
            var s = end;

            while (s != start)
            {
                road.Add(s);                /* on ajoute s à la suite raod */
                s = _prédécesseur[s];       /* on continue de suivre le chemin */
            }

            return road;
        }
    }
}
