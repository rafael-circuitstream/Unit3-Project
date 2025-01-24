using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
//Puzzle class determines what every puzzle in the game will have
public abstract class Puzzle : MonoBehaviour
{
    //Every puzzle will keep track of all IPuzzlePiece in children
    protected IPuzzlePiece[] allPuzzlePieces;
    private void Awake()
    {
        //Find all components that are children of this GameObject
        allPuzzlePieces = GetComponentsInChildren<IPuzzlePiece>();
    }


    //An event to happen when it is completed, recomended to be use for custom and specific things
    public UnityEvent OnPuzzleCompleted;

    //bool to set TRUE when puzzle is completed
    public bool isPuzzleComplete;

    //Method that will check the solution, make any calculations to detect if its correct or not
    public abstract bool CheckSolution();
}
