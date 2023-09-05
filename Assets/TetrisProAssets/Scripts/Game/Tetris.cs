using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace JueguitosPro
{
    public enum TetrisLetters
    {
        I,
        O,
        T,
        J,
        L,
        S,
        Z,
    }

    [Serializable]
    public struct TetrisData
    {
        public TetrisLetters tetrisLetter;
        public Tile tile;
        public Vector2Int[] cells { get; private set; }
        public Vector2Int[,] wallKicks { get; private set; }

        
        public void Initialize()
        {
            cells = Data.Cells[tetrisLetter];
            wallKicks = Data.WallKicks[tetrisLetter];
        }
    }
}
