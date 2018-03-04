﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Util
{
    public class Map: IEnumerable<Cell>, ICloneable
    {        
        public Map Fill(Random random, int randomFillPercent)
        {
            var map = Copy();
            map.ForEach(cell => cell.Value = IsEdge(cell) ? 1 : GenerateValue(random, randomFillPercent));
            return map;
        }

        public Map Smooth(int steps, int maxWallCount, int neighbourOffset)
        {
            var map = Copy();
            for (var step = 0; step < steps; step++)
                map.Where(cell => !map.IsEdge(cell))
                    .ForEach(cell => {
                    var wallCount = map.NeighboursOf(cell, neighbourOffset)
                        .Select(neighbour => neighbour.Value)
                        .Sum();
                    
                    if(wallCount > maxWallCount)
                        cell.Value = 1;
                    else if (wallCount < maxWallCount)
                        cell.Value = 0;
                });
            return map;
        }

        public List<Cell> NeighboursOf(Cell cell, int offset)
        {
            List<Cell> neighbours = new List<Cell>();
            for (var neighbourX = cell.Point.X - offset; neighbourX <= cell.Point.X + offset; neighbourX++)
            {
                for (var neighbourY = cell.Point.Y - offset; neighbourY <= cell.Point.Y + offset; neighbourY++)
                {
                    var neighbourPoint = new Point(neighbourX, neighbourY);

                    if(Contains(neighbourPoint) && !cell.Point.Equals(neighbourPoint))
                       neighbours.Add(new Cell(this, neighbourPoint));
                }
            }
            return neighbours;
        }
        
        public bool Contains(Point point)
        {
            return point.X >= 0 && point.X < Width && point.Y >= 0 && point.Y < Height;
        }

        public bool IsEdge(Cell cell)
        {
            return IsEdge(cell.Point);
        }

        public bool IsEdge(Point point)
        {
            return point.X == 0 || point.Y == 0 || point.X == Width - 1 || point.Y == Height - 1;
        }

        #region Properties

        int[,] Positions
        {
            get
            {
                return map ?? (map = new int[width, height]);
            }
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
                for (var y = 0; y < Height; y++)
                    yield return new Cell(this, new Point(x, y));
        }
        
        Map Copy()
        {
            return (Map) Clone();
        }
        
        public object Clone()
        {
            var clone = new Map(width, height);
            if (map == null) return clone;

            clone.ForEach(cell => cell.Value = Value(cell.Point));
            return clone;
        }

        internal int Value(Point point)
        {
            return Positions[point.X, point.Y];
        }
        
        internal void Value(Point point, int value)
        {
            Positions[point.X, point.Y] = value;
        }

        int GenerateValue(Random random, int randomFillPercent)
        {
            return random.Next(0, 100) < randomFillPercent ? 1 : 0;
        }

        #endregion

        #region Constructors
        
        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        #endregion
        
        #region Attributes
        
        int[,] map;

        int width;

        int height;
        
        #endregion
    }
}