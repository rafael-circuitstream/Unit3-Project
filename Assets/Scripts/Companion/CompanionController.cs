using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionController : MonoBehaviour
{
    [SerializeField] private Queue<Command> commandQueue = new Queue<Command>();
    
    //Command myElement = commandQueue.Dequeue();
    //the first element is now inside the variable "myElement"
    //the second element is now the first

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Debug.Log("Commands in queue: " + commandQueue.Count);
        if(commandQueue.Count > 0)
        {
            Debug.Log("Executing commands");
            commandQueue.Peek().Execute();
            if(commandQueue.Peek().IsCommandComplete())
            {
                Debug.Log("About to finish command");
                FinishCommand();
            }
        }
    }

    public void GiveCommand(Command newCommand)
    {
        newCommand.SetCompanionController(this);
        commandQueue.Enqueue(newCommand);

    }

    public void FinishCommand()
    {
        commandQueue.Dequeue();
    }

    public NavMeshAgent GetNavMeshAgent()
    {
        return agent;
    }
}
