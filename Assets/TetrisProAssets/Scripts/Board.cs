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
        public Tilemap tilemap { get; private set; }
        public TetrisData[] tetrisData;
        public Piece activePiece { get; private set; }
        public Vector3Int spawnPosition;
        
        private void Awake()
        {
            tilemap = GetComponentInChildren<Tilemap>();
            activePiece = GetComponentInChildren<Piece>();
            
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
    }
}
