using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPuzzle : Puzzle
{

    private void Update()
    {
        //Check solution is executed every frame until isPuzzleComplete is true
        if(CheckSolution() && isPuzzleComplete == false)
        {
            OnPuzzleCompleted?.Invoke();
            isPuzzleComplete = true;
        }
    }

    //CheckSolution is as simple as it is, it checks for all "pieces" in the puzzle.
    //If any piece is incorrect, CheckSolution returns false as the puzzle is not complete
    public override bool CheckSolution()
    {
        foreach (IPuzzlePiece piece in allPuzzlePieces)
        {
            if (!piece.IsCorrect())
            {
                return false;
            }
        }

        //If none of the pieces gives a false value, then return true
        return true;
    }
     
    //This could help with optimization for the game, but we can look at this next class

    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPuzzleActive = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPuzzleActive = false;
        }
    }
    */
}
