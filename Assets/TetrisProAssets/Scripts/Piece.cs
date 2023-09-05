using UnityEngine;

namespace JueguitosPro
{
    // Use to controls 
    public class Piece : MonoBehaviour
    {
        private static readonly float PIECE_OFFSET = 0.5f;
        public Board board { get; private set; }
        public Vector3Int position { get; private set; }
        public TetrisData tetrisData { get; private set; }
        public Vector3Int[] cells { get; private set; }
        public int rotationIndex { get; private set; }

        public float stepDelay = 1f;
        public float lockDelay = 0.5f;

        private float stepTime;
        private float lockTime;
        
        public void Initialize(Board board, Vector3Int position, TetrisData tetrisData)
        {
            this.board = board;
            this.position = position;
            this.tetrisData = tetrisData;
            rotationIndex = 0;

            stepTime = Time.time + stepDelay;
            lockTime = 0f;

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

            lockTime += Time.deltaTime;

            //TODO: The inputs will be refactor in the next PR, this is only for base game
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
                if (Move(Vector2Int.down))
                {
                    board.scoringSystem.AddSlowDropPoints();
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                HardDrop();
            }

            if (Time.time >= stepTime)
            {
                Step();
            }
            
            board.Set(this);
        }

        private void Step()
        {
            stepTime = Time.time + stepDelay;
            Move(Vector2Int.down);
            if (lockTime >= lockDelay)
            {
                Lock();
            }
        }

        private void Lock()
        {
            board.Set(this);
            board.ClearLines();
            board.SpawnPiece();
        }

        private void HardDrop()
        {
            while (Move(Vector2Int.down))
            {
                board.scoringSystem.AddHardDropPoints();
                continue;
            }

            Lock();
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
                lockTime = 0f;
            }

            return isValid;
        }

        private void Rotate(int direction)
        {
            int originalRotationIndex = rotationIndex;
            
            // The piece rotation only has 4 different positions https://tetris.fandom.com/wiki/SRS
            rotationIndex += Wrap(rotationIndex + direction,0, 4);

            ApplyRotationMatrix(direction);

            if (!CheckWallKicks())
            {
                rotationIndex = originalRotationIndex;
                ApplyRotationMatrix(-direction);
            }
        }

        private void ApplyRotationMatrix(int direction)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                // Not use Vector3Int because the I and O needs to has an offset of half unit (0.5)
                Vector3 cell = cells[i];
                int x;
                int y;

                switch (tetrisData.tetrisLetter)
                {
                    case TetrisLetters.I:
                    case TetrisLetters.O:
                        cell.x -= PIECE_OFFSET;
                        cell.y -= PIECE_OFFSET;
                        
                        // Use Ceil to rounds upwards instead of the near integer
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

        /// <summary>
        /// This method check if the piece collide with a wall/other piece and move the piece in the direction that doesnt collide with other thing
        /// </summary>
        /// <returns></returns>
        private bool CheckWallKicks()
        {
            for (int wallKickIndex = 0; wallKickIndex < tetrisData.wallKicks.Length; wallKickIndex++)
            {
                for (int i = 0; i < tetrisData.wallKicks.GetLength(1); i++)
                {
                    Vector2Int translation = tetrisData.wallKicks[wallKickIndex, i];
                    if (Move(translation))
                    {
                        return true;
                    }
                }
            }

            return false;

        }
    }
}
