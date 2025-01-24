using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//An interface that gives the ability of any monobehaviour to be linked to a puzzle
//consecutively, to be checked if its correct
public interface IPuzzlePiece
{
    //Optional:
    //public void LinkToPuzzle(Puzzle p);
    
    //similar to IsPuzzleComplete() from Puzzle.cs,  but for an individual piece
    public bool IsCorrect();

}
