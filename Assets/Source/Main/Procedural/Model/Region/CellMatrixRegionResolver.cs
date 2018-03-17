using System.Collections.Generic;
using System.Linq;
using Util;

namespace Procedural.Model {
    public class CellMatrixRegionResolver {
        public IEnumerable<Region> Resolve(CellValue value) {
            InitializeVisited();
            return cellMatrix
                .Where(cell => Equals(cell.Value, value))
                .Aggregate(new List<Region>(), (regions, cell) => {
                    if (isVisited(cell)) return regions;

                    var regionCells = GetContainerRegionOf(cell, value);
                    regionCells.ForEach(MakeVisited);

                    var region = new Region(regionCells, GetEdgeCells(regionCells));

                    regions.Add(region);
                    return regions;
                });
        }

        private IEnumerable<Cell> GetEdgeCells(IEnumerable<Cell> regionCells) {
            return regionCells
                .SelectMany(cell => cellMatrix.NeighbourOf(cell, RADIO)
                .Where(it => it.isWall()));               
        }

        private IEnumerable<Cell> GetContainerRegionOf(Cell startCell, CellValue value) {
            var regionCells = new List<Cell>();
            var incomingCells = new Queue<Cell>();
            incomingCells.Enqueue(startCell);
            MakeVisited(startCell);

            while (incomingCells.Count > 0){
                var centralCell = incomingCells.Dequeue();
                regionCells.Add(centralCell);

                cellMatrix
                    .RadialForEach(centralCell, RADIO)
                    .Where(cellMatrix.Contains)
                    .WhereNot(cellMatrix.IsEdge)
                    .Where(cell => Equals(cell.Value, value))
                    .WhereNot(isVisited)
                    .ForEach(cell => {
                        MakeVisited(cell);
                        incomingCells.Enqueue(cell);
                    });
            }

            return regionCells;
        }

        private void MakeVisited(Cell cell) {
            visitedCells[cell.Coord.X, cell.Coord.Y] = true;
        }

        private bool isVisited(Cell cell) {
            return visitedCells[cell.Coord.X, cell.Coord.Y];
        }

        private void InitializeVisited() {
            visitedCells = new bool[cellMatrix.Width, cellMatrix.Height];
        }

        private const int RADIO = 1;

        private bool[,] visitedCells;

        private readonly CellMatrix cellMatrix;

        public CellMatrixRegionResolver(CellMatrix cellMatrix) {
            this.cellMatrix = cellMatrix;
        }
    }
}
