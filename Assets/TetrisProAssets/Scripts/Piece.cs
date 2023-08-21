using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
        public int rotationIndex { get; private set; }
        
        public void Initialize(Board board, Vector3Int position, TetrisData tetrisData)
        {
            this.board = board;
            this.position = position;
            this.tetrisData = tetrisData;
            rotationIndex = 0;

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

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Rotate(-1);
            } 
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Rotate(1);
            }
            
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

        private void Rotate(int direction)
        {
            rotationIndex += Wrap(rotationIndex + direction, 0,4);

            for (int i = 0; i < cells.Length; i++)
            {
                // Not use Int beacuse the I and O needs to has an offset of half unit (0.5)
                Vector3 cell = cells[i];
                int x;
                int y;

                switch (tetrisData.tetrisLetter)
                {
                    case TetrisLetters.I:
                    case TetrisLetters.O:
                        cell.x -= 0.5f;
                        cell.y -= 0.5f;
                        x = Mathf.CeilToInt((cell.x * Data.RotationMatrix[0] * direction) + (cell.y * Data.RotationMatrix[1] * direction));
                        y = Mathf.CeilToInt((cell.x * Data.RotationMatrix[2] * direction) + (cell.y * Data.RotationMatrix[3] * direction));
                        break;
                    default:
                        x = Mathf.RoundToInt((cell.x * Data.RotationMatrix[0] * direction) + (cell.y * Data.RotationMatrix[1] * direction));
                        y = Mathf.RoundToInt((cell.x * Data.RotationMatrix[2] * direction) + (cell.y * Data.RotationMatrix[3] * direction));
                        break;
                }

                cells[i] = new Vector3Int(x, y, 0);
            }
            
        }

        private int Wrap(int input, int min, int max)
        {
            if (input < min)
            {
                return max - (min - input) % (max - min);
            }

            return min + (input - min) % (max - min);
        }

    }
}
