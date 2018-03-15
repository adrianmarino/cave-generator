using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Util;
using Random = System.Random;

namespace Procedural.Model
{   
    public class CellMatrix: IEnumerable<Cell>
    {
        public Cell this[int x, int y]
        {
            get { return new Cell(this, new Coord(x, y)); }
        }

        public CellMatrix MakeBorders()
        {
            this.Where(IsEdge).ForEach(cell => cell.MakeWall());
            return this;
        }

        public CellMatrix RemoveRegions(int cellSize)
        {
            if(cellSize <= 0)
                return this;

            return swapRegionCellValues(region => region.Count < cellSize, Cell.WALL_VALUE, Cell.FLOOR_VALUE)
                .swapRegionCellValues(region => region.Count < cellSize, Cell.FLOOR_VALUE, Cell.WALL_VALUE);
        }

        public CellMatrix swapRegionCellValues(
            Predicate<Region> regionFilter, 
            int beforeCellValue, 
            int afterCellValue
        )
        {
            RegionsWith(beforeCellValue)
                .Where(region => regionFilter(region))
                .ForEach(region => region.Reset(afterCellValue));
            return this;
        }
        
        public List<Region> RegionsWith(int CellValue)
        {
            return new CellMatrixRegionResolver(this).Resolve(CellValue);
        }

        public CellMatrix Fill(Random random, int randomFillPercent)
        {
            this.ForEach(cell => cell.Value = IsEdge(cell) ? 1 : GenerateValue(random, randomFillPercent));
            return this;
        }

        public CellMatrix Smooth(int steps, int maxActiveNeighbors, int neighboursRadio)
        {
            for (var step = 0; step < steps; step++)
                this.WhereNot(IsEdge)
                    .ForEach(cell => {
                        var activeNeighbors = 
                            NeighboursOf(cell, neighboursRadio)
                            .Select(neighbour => neighbour.Value)
                            .Sum();

                        if(activeNeighbors > maxActiveNeighbors)
                            cell.MakeWall();
                        else if (activeNeighbors < maxActiveNeighbors)
                            cell.MakeFloor();
                    });
            return this;
        }

        public IEnumerable<Cell> NeighboursOf(Cell centralCell, int radio)
        {
            return this
                .RadialForEach(centralCell, radio)
                .Where(Contains)
                .WhereNot(cell => cell.Equals(centralCell))
                .Aggregate(new List<Cell>(), (neighbours , cell) => {
                    neighbours.Add(cell);
                    return neighbours;
                });       
        }


        public bool Contains(Cell cell)
        {
            return Contains(cell.Coord);
        }

        private bool Contains(Coord coord)
        {
            return coord.X >= 0 && coord.X < Width && coord.Y >= 0 && coord.Y < Height;
        }

        public bool IsEdge(Cell cell)
        {
            return IsEdge(cell.Coord);
        }

        private bool IsEdge(Coord coord)
        {
            return coord.X <= borderSize || coord.Y <= borderSize || coord.X >= Width - borderSize || coord.Y >= Height - borderSize;
        }

        #region Properties

        private int[,] Positions
        {
            get
            {
                return map ?? (map = new int[width, height]);
            }
        }

        public Vector3 BottomLeft
        {
            get { return new Vector3(-Width / 2, 0, -Height / 2); }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        #endregion
        
        #region Private Methods
                
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    yield return new Cell(this, new Coord(x, y));
                }
            }
        }

        internal int Value(Coord coord)
        {
            return Positions[coord.X, coord.Y];
        }
        
        internal void Value(Coord coord, int value)
        {
            Positions[coord.X, coord.Y] = value;
        }

        int GenerateValue(Random random, int randomFillPercent)
        {
            return random.Next(0, 100) < randomFillPercent ? 1 : 0;
        }

        #endregion

        #region Constructors
        
        public CellMatrix(int width, int height, int borderSize)
        {
            this.width = width;
            this.height = height;
            this.borderSize = borderSize;
        }

        #endregion
        
        #region Attributes
        
        int[,] map;

        readonly int width;

        readonly int height;

        private readonly int borderSize;

        #endregion
    }
}