using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public bool isConnected(Region region) {
            return passages.Any(it => it.Contains(this, region));
        }

        public void Passage(RegionPassage passage) {
            passages.Add(passage);
        }

        public int Count {
            get { return cells.Count; }
        }

        private readonly IList<RegionPassage> passages;
        
        private readonly IList<Cell> cells;

        public IEnumerable<Cell> EdgeCells { get; private set; }

        public Region(IEnumerable<Cell> cells, IEnumerable<Cell> edgeCells) {
            this.cells = cells.ToList();
            this.EdgeCells = edgeCells;
            passages = new List<RegionPassage>();
        }
    }
}
