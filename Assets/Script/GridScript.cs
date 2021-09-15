using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinePaint
{

    public class GridScript
    {
        private int _width;
        private int _height;
        private float _cellSize;

        private int[,] gridArray;

        public int[,] GridArray { get { return gridArray; } }

        public void Initialize(int width, int height, float cellSize)
        {
            _width = width;
            _height = height;
            _cellSize = cellSize;

            gridArray = new int[width, height];
        }

    }

}
