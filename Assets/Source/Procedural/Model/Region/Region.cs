using System.Collections;
using System.Collections.Generic;
using Util;

namespace Procedural.Model {
    public class Region : IEnumerable<Cell> {
        public IEnumerator<Cell> GetEnumerator() {
            foreach (var cell in cells)
                yield return cell;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public void SetAllValues(CellValue value) {
            this.ForEach(cell => cell.Value = value);
        }

        public int Count {
            get { return cells.Count; }
        }

        public List<Cell> Cells {
            get { return cells; }
        }

        private readonly List<Cell> cells;

        public Region(List<Cell> cells) {
            this.cells = cells;
        }
    }
}