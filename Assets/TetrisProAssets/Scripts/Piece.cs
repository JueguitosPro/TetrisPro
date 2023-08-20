using System;
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

        private void Update()
        {
            board.Clear(this);
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(Vector2Int.left);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Move(Vector2Int.right);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(Vector2Int.down);
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                HardDrop();
            }
            
            board.Set(this);
        }

        private void HardDrop()
        {
            while (Move(Vector2Int.down))
            {
                continue;
            }
        }

        private bool Move(Vector2Int direction)
        {
            Vector3Int newPos = position;
            newPos.x += direction.x;
            newPos.y += direction.y;

            bool isValid = board.isValidPosition(this, newPos);

            if (isValid)
            {
                position = newPos;
            }

            return isValid;
        }
    }
}
