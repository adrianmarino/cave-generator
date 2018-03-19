using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using UnityEditor;
using Util;

namespace Procedural.Model {
    public class Region : IEnumerable<Cell> {
        public IEnumerator<Cell> GetEnumerator() {
            return cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public void ResetValues(CellValue value) {
            this.ForEach(cell => cell.Value = value);
        }

        public bool IsConnected(Region otherRegion) {
            return passages.Any(it => it.Contains(this, otherRegion));
        }

        public bool Reach(Region otherRegion) {
            return Reach(this, otherRegion) || Reach(otherRegion, this);
        }

        private static bool Reach(Region origin, Region destiny) {
            var incommingRegion = new Queue<Region>();
            incommingRegion.Enqueue(origin);

            while (incommingRegion.Count > 0){
                var region = incommingRegion.Dequeue();

                if (region.Equals(destiny)) return true;

                region.passages.ForEach(it => incommingRegion.Enqueue(it.RegionB));
            }
            return false;
        }

        public void Passage(RegionPassage passage) {
            passages.Add(passage);
        }

        public IEnumerable<Cell> EdgeCells { get; private set; }
        
        public ReadOnlyCollection<RegionPassage> Passages {
            get { return new ReadOnlyCollection<RegionPassage>(passages); }
        }

        public int Count {
            get { return cells.Count; }
        }

        private readonly IList<RegionPassage> passages;

        private readonly IList<Cell> cells;

        public Region(IEnumerable<Cell> cells, IEnumerable<Cell> edgeCells) {
            this.cells = cells.ToList();
            EdgeCells = edgeCells;
            passages = new List<RegionPassage>();
        }
    }
}
