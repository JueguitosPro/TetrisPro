using System;
using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] private Vector2Int boardSize = new Vector2Int(10, 20);


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
            TetrisData data = tetrisData[random];
            
            activePiece.Initialize(this, spawnPosition, data);
            Set(activePiece);
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
        
    }
}
