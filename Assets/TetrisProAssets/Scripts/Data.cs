using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JueguitosPro
{
    public static class Data
    {

        public static readonly float cos = Mathf.Cos(Mathf.PI / 2f);
        public static readonly float sin = Mathf.Sin(Mathf.PI / 2f);
        public static readonly float[] RotationMatrix = new float[] { cos, sin, -sin, cos };

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

        private static readonly Vector2Int[,] WallKicksI = new Vector2Int[,]
        {
            {
                new Vector2Int(0, 0), new Vector2Int(-2, 0), new Vector2Int(1, 0), new Vector2Int(-2, -1),
                new Vector2Int(1, 2)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(2, 0), new Vector2Int(-1, 0), new Vector2Int(2, 1),
                new Vector2Int(-1, -2)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(-1, 0), new Vector2Int(2, 0), new Vector2Int(-1, 2),
                new Vector2Int(2, -1)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(-2, 0), new Vector2Int(1, -2),
                new Vector2Int(-2, 1)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(2, 0), new Vector2Int(-1, 0), new Vector2Int(2, 1),
                new Vector2Int(-1, -2)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(-2, 0), new Vector2Int(1, 0), new Vector2Int(-2, -1),
                new Vector2Int(1, 2)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(-2, 0), new Vector2Int(1, -2),
                new Vector2Int(-2, 1)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(-1, 0), new Vector2Int(2, 0), new Vector2Int(-1, 2),
                new Vector2Int(2, -1)
            },
        };

        private static readonly Vector2Int[,] WallKicksJLOSTZ = new Vector2Int[,]
        {
            {
                new Vector2Int(0, 0), new Vector2Int(-1, 0), new Vector2Int(-1, 1), new Vector2Int(0, -2),
                new Vector2Int(-1, -2)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(1, -1), new Vector2Int(0, 2),
                new Vector2Int(1, 2)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(1, -1), new Vector2Int(0, 2),
                new Vector2Int(1, 2)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(-1, 0), new Vector2Int(-1, 1), new Vector2Int(0, -2),
                new Vector2Int(-1, -2)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(1, 1), new Vector2Int(0, -2),
                new Vector2Int(1, -2)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(-1, 0), new Vector2Int(-1, -1), new Vector2Int(0, 2),
                new Vector2Int(-1, 2)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(-1, 0), new Vector2Int(-1, -1), new Vector2Int(0, 2),
                new Vector2Int(-1, 2)
            },
            {
                new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(1, 1), new Vector2Int(0, -2),
                new Vector2Int(1, -2)
            },
        };

        public static readonly Dictionary<TetrisLetters, Vector2Int[,]> WallKicks =
            new Dictionary<TetrisLetters, Vector2Int[,]>()
            {
                { TetrisLetters.I, WallKicksI },
                { TetrisLetters.J, WallKicksJLOSTZ },
                { TetrisLetters.L, WallKicksJLOSTZ },
                { TetrisLetters.O, WallKicksJLOSTZ },
                { TetrisLetters.S, WallKicksJLOSTZ },
                { TetrisLetters.T, WallKicksJLOSTZ },
                { TetrisLetters.Z, WallKicksJLOSTZ },
            };
    }
}
