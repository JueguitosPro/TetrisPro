using UnityEngine;
using UnityEngine.Tilemaps;

namespace JueguitosPro
{
    public class Ghost : MonoBehaviour
    {
        public Tile tile;
        public Board board;
        public Piece trackingPiece;
        
        public Tilemap tilemap { get; private set; }
        public Vector3Int[] cells { get; private set; }
        public Vector3Int position { get; private set; }

        private void Awake()
        {
            tilemap = GetComponentInChildren<Tilemap>();
            
            // 4 is because the piece has 4 squares
            cells = new Vector3Int[4];
            
        }

        private void LateUpdate()
        {
            Clear();
            Copy();
            Drop();
            Set();
        }

        private void Set()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                Vector3Int tilePos = cells[i] + position; 
                tilemap.SetTile(tilePos, tile);
            }
        }

        private void Clear()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                Vector3Int tilePos = cells[i] + position; 
                tilemap.SetTile(tilePos, null);
            }
        }

        private void Copy()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = trackingPiece.cells[i];
            }
        }

        private void Drop()
        {
            Vector3Int newPosition = trackingPiece.position;

            int current = newPosition.y;
            int bottom = (-board.boardSize.y / 2) - 1;

            board.Clear(trackingPiece);
            
            for (int row = current; row >= bottom; row--)
            {
                newPosition.y = row;
                if (board.isValidPosition(trackingPiece, newPosition))
                {
                    position = newPosition;
                }
                else
                {
                    break;
                }
            }
            board.Set(trackingPiece);
        }
    }
}
