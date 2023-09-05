using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;


namespace JueguitosPro
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemap;
        [SerializeField] private Piece activePiece;
        [SerializeField] private TetrisData[] tetrisData;
        [SerializeField] private Vector3Int spawnPosition;
        public Vector2Int boardSize = new Vector2Int(10, 20);
        
        // TEMP
        public ScoringSystem scoringSystem;
        
        public RectInt bounds
        {
            get
            {
                Vector2Int position = new Vector2Int(-boardSize.x / 2, -boardSize.y / 2);
                return new RectInt(position, boardSize);
            }
        }
        
        private void Awake()
        {
            for (int i = 0; i < tetrisData.Length; i++)
            {
                tetrisData[i].Initialize();
            }
        }

        private void Start()
        {
            SpawnPiece();
        }

        public void SpawnPiece()
        {
            int random = Random.Range(0, tetrisData.Length);
            TetrisData data = tetrisData[0];
            
            activePiece.Initialize(this, spawnPosition, data);

            if (isValidPosition(activePiece, spawnPosition))
            {
                Set(activePiece);
            }
            else
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            // TODO: Implement the game over
            Debug.LogError("GAME OVER");
            tilemap.ClearAllTiles();
            scoringSystem.ResetPoints();
        }

        public void Set(Piece piece)
        {
            for (int i = 0; i < piece.cells.Length; i++)
            {
                Vector3Int tilePos = piece.cells[i] + piece.position; 
                tilemap.SetTile(tilePos, piece.tetrisData.tile);
            }
        }
        
        public void Clear(Piece piece)
        {
            for (int i = 0; i < piece.cells.Length; i++)
            {
                Vector3Int tilePos = piece.cells[i] + piece.position; 
                tilemap.SetTile(tilePos, null);
            }
        }

        public bool isValidPosition(Piece piece, Vector3Int position)
        {
            RectInt currentBounds = bounds;
            
            for (int i = 0; i < piece.cells.Length; i++)
            {
                Vector3Int tilePos = piece.cells[i] + position;

                if (!currentBounds.Contains((Vector2Int)tilePos))
                {
                    return false;
                }

                if (tilemap.HasTile(tilePos))
                {
                    return false;
                }
            }

            return true;
        }

        public void ClearLines()
        {
            int row = bounds.yMin;
            int lines = 0;
            
            // if the line is full we need to re test the line because all the above lines will fall down
            while (row < bounds.yMax)
            {
                if (IsLineFull(row))
                {
                    lines++;
                    LineClear(row);
                }
                else
                {
                    row++;
                }
            }
            scoringSystem.LineCompleted(lines, 1);
        }

        private bool IsLineFull(int row)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row, 0);
                if (!tilemap.HasTile(position))
                {
                    return false;
                }
            }

            return true;
        }

        private void LineClear(int row)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row, 0);
                tilemap.SetTile(position, null);
            }

            while (row < bounds.yMax)
            {
                for (int col = bounds.xMin; col < bounds.xMax; col++)
                {
                    Vector3Int position = new Vector3Int(col, row + 1, 0);
                    TileBase above = tilemap.GetTile(position);
            
                    position = new Vector3Int(col, row, 0);
                    tilemap.SetTile(position, above);
                }
            
                row++;
            }
        }
    }
}
