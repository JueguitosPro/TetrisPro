using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JueguitosPro
{
    public static class Data
    {
        ///////// All the tetris tiles definitions
        public static readonly Dictionary<TetrisLetters, Vector2Int[]> Cells =
            new Dictionary<TetrisLetters, Vector2Int[]>()
            {
                {
                    TetrisLetters.I,
                    new Vector2Int[]
                        { new Vector2Int(-1, 1), new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(2, 1) }
                },
                {
                    TetrisLetters.O,
                    new Vector2Int[]
                        { new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(0, 0), new Vector2Int(1, 0) }
                },
                {
                    TetrisLetters.T,
                    new Vector2Int[]
                        { new Vector2Int(0, 1), new Vector2Int(-1, 0), new Vector2Int(0, 0), new Vector2Int(1, 0) }
                },
                {
                    TetrisLetters.J,
                    new Vector2Int[]
                        { new Vector2Int(-1, 1), new Vector2Int(-1, 0), new Vector2Int(0, 0), new Vector2Int(1, 0) }
                },
                {
                    TetrisLetters.L,
                    new Vector2Int[]
                        { new Vector2Int(1, 1), new Vector2Int(-1, 0), new Vector2Int(0, 0), new Vector2Int(1, 0) }
                },
                {
                    TetrisLetters.S,
                    new Vector2Int[]
                        { new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(-1, 0), new Vector2Int(0, 0) }
                },
                {
                    TetrisLetters.Z,
                    new Vector2Int[]
                        { new Vector2Int(-1, 1), new Vector2Int(0, 1), new Vector2Int(0, 0), new Vector2Int(1, 0) }
                },
            };

   
    }
}