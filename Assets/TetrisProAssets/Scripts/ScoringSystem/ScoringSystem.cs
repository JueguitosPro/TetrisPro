using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace JueguitosPro
{
    public class ScoringSystem : MonoBehaviour
    {
        public static readonly int SLOW_DROP_POINTS_PER_CELL = 1; 
        public static readonly int HARD_DROP_POINTS_PER_CELL = 2;
        
        public static readonly int SINGLE_LINE_POINTS = 100;
        public static readonly int DOUBLE_LINE_POINTS = 300;
        public static readonly int TRIPLE_LINE_POINTS = 500;
        public static readonly int TETRIS_POINTS = 800;

        [SerializeField] private int currentScore = 0;
        [SerializeField] private int consecutiveLines = 0;
        [SerializeField] private bool lastMoveWasTetris = false;
        [SerializeField] private int lastClearedLinesAmount = 0;
        [SerializeField] private int dropCells = 0;
        [SerializeField] private int currentDropPoints = 0;
        
        public void AddSlowDropPoints()
        {
            currentScore += SLOW_DROP_POINTS_PER_CELL;
            currentDropPoints = SLOW_DROP_POINTS_PER_CELL;
            dropCells++;
        }
        public void AddHardDropPoints()
        {
            currentScore += HARD_DROP_POINTS_PER_CELL;
            currentDropPoints = HARD_DROP_POINTS_PER_CELL;
            dropCells++;
        }

        public void LineCompleted(int linesCleared, int level = 1)
        {
            if (linesCleared == 0)
            {
                consecutiveLines = 0;
            }
            
            int linesCore = 0;
            
            switch (linesCleared)
            {
                case 1:
                    linesCore += SINGLE_LINE_POINTS * level;
                    break;
                case 2:
                    linesCore += DOUBLE_LINE_POINTS * level;
                    break;
                case 3:
                    linesCore += TRIPLE_LINE_POINTS * level;
                    break;
                case 4:
                    linesCore += TETRIS_POINTS * level;
                    break;
            }

            if (consecutiveLines > 0)
            {
                linesCore += ((currentDropPoints * dropCells) +50) * level;
            } 
            dropCells = 0;
            
            consecutiveLines += linesCleared;
            
            if (lastMoveWasTetris && lastClearedLinesAmount >= 4)
            {
                linesCore *= 2;
            }
            
            currentScore += linesCore;

            if (linesCleared > 0)
            {
                lastClearedLinesAmount = linesCleared;
                lastMoveWasTetris = (linesCleared >= 4);
            }
            

        }
        
        public void ResetPoints()
        {
            currentScore = 0;
        }
    }
}
