using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JueguitosPro
{
    // Use to controls 
    public class Piece : MonoBehaviour
    {
        public Board board { get; private set; }
        public Vector3Int position { get; private set; }
        public TetrisData tetrisData { get; private set; }
        public Vector3Int[] cells { get; private set; }
        
        
        public void Initialize(Board board, Vector3Int position, TetrisData tetrisData)
        {
            this.board = board;
            this.position = position;
            this.tetrisData = tetrisData;

            if (cells == null)
            {
                cells = new Vector3Int[tetrisData.cells.Length];
            }

            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = (Vector3Int)tetrisData.cells[i];
            }
            
        }
    }
}
