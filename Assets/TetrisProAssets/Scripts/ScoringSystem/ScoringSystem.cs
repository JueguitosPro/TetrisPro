using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace JueguitosPro
{
    public class ScoringSystem : MonoBehaviour
    {
        [SerializeField] private int currentScore = 0;
        [SerializeField] private int consecutiveLines = 0;
        [SerializeField] private bool lastMoveWasTetris = false;
        [SerializeField] private int lastClearedLinesAmount = 0;
        [SerializeField] private int dropCells = 0;
        [SerializeField] private int currentDropPoints = 0;
        
        public void AddSlowDropPoints()
        {
            currentScore += Constants.SLOW_DROP_POINTS_PER_CELL;
            currentDropPoints = Constants.SLOW_DROP_POINTS_PER_CELL;
            dropCells++;
        }
        
        public void AddHardDropPoints()
        {
            currentScore += Constants.HARD_DROP_POINTS_PER_CELL;
            currentDropPoints = Constants.HARD_DROP_POINTS_PER_CELL;
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
                    linesCore += Constants.SINGLE_LINE_POINTS * level;
                    break;
                case 2:
                    linesCore += Constants.DOUBLE_LINE_POINTS * level;
                    break;
                case 3:
                    linesCore += Constants.TRIPLE_LINE_POINTS * level;
                    break;
                case 4:
                    linesCore += Constants.TETRIS_POINTS * level;
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
