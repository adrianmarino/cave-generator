using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Util;
using Random = System.Random;

namespace Procedural.Model {
    public class CellMatrix : IEnumerable<Cell>, ITwoDimensionIndexable<Cell> {
        public CellMatrix MakeBorders() {
            this.Where(IsEdge).ForEach(cell => cell.MakeWall());
            return this;
        }

        public CellMatrix Fill(IFillStrategy fillStrategy) {
            this.ForEach(cell => cell.Value = IsEdge(cell) ? CellValue.Wall : fillStrategy.Next());
            return this;
        }

        public IEnumerable<Region> ResetRegionsWithCellCountLessThan(int cellSize) {
            return SwapRegionValues(CellValue.Floor, CellValue.Wall, it => it.Count < cellSize)
                .Concat(SwapRegionValues(CellValue.Wall, CellValue.Floor,it => it.Count < cellSize));
        }

        public CellMatrix Smooth(int steps, int maxSurroundWalls, int wallsSearchRadio) {
            for (var step = 0; step < steps; step++)
                this.WhereNot(IsEdge).ForEach(cell => {
                    var surroundWalls = SurroundWallsCount(cell, wallsSearchRadio);

                    if (surroundWalls > maxSurroundWalls) cell.MakeWall();
                    else if (surroundWalls < maxSurroundWalls) cell.MakeFloor();
                });
            return this;
        }

        public IEnumerable<Region> SwapRegionValues(
            CellValue previousValue,
            CellValue laterValue,
            Func<Region, bool> where
        ) {
            var regionGroups = RegionsBy(previousValue).ToLookup(where);
            regionGroups[true].ResetValues(laterValue);
            return regionGroups[false];
        }

        public IEnumerable<Region> RegionsBy(CellValue value) {
            return new CellMatrixRegionResolver(this).Resolve(value);
        }

        private int SurroundWallsCount(Cell centralCell, int radio) {
            return this.RadialForEach(centralCell, radio)
                .Where(Contains)
                .WhereNot(Equals)
                .Select(Cell.IntValue)
                .Sum();
        }

        public bool Contains(Cell cell) {
            var coord = cell.Coord;
            return coord.X >= 0 && coord.X < Width && coord.Y >= 0 && coord.Y < Height;
        }

        public bool IsEdge(Cell cell) {
            var coord = cell.Coord;
            return coord.X <= borderSize || coord.Y <= borderSize || coord.X >= Width - borderSize ||
                   coord.Y >= Height - borderSize;
        }

        #region Properties

        private CellValue[,] Positions {
            get { return map ?? (map = new CellValue[width, height]); }
        }

        public Vector3 BottomLeft {
            get { return new Vector3(-Width / 2, 0, -Height / 2); }
        }

        public int Width {
            get { return width; }
        }

        public int Height {
            get { return height; }
        }

        #endregion

        #region Enumeration

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public IEnumerator<Cell> GetEnumerator() {
            for (var x = 0; x < Width; x++){
                for (var y = 0; y < Height; y++){
                    yield return new Cell(this, new Coord(x, y));
                }
            }
        }

        public Cell this[int x, int y] {
            get { return new Cell(this, new Coord(x, y)); }
        }

        #endregion

        #region Cell Value management

        internal CellValue Value(Coord coord) {
            return Positions[coord.X, coord.Y];
        }

        internal void Value(Coord coord, CellValue value) {
            Positions[coord.X, coord.Y] = value;
        }

        #endregion

        #region Constructors

        public CellMatrix(int width, int height, int borderSize) {
            this.width = width;
            this.height = height;
            this.borderSize = borderSize;
        }

        #endregion

        #region Attributes

        CellValue[,] map;

        readonly int width;

        readonly int height;

        private readonly int borderSize;

        #endregion
    }
}
