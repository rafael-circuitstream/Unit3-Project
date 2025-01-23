using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private Vector3 target;
    public override void Cancel()
    {
       
    }
    
    public override void Execute()
    {
        //if (companionController.GetNavMeshAgent().hasPath) return;
        companionController.GetNavMeshAgent().SetDestination(target);

    }

    public override bool IsCommandComplete()
    {
        //if (!companionController.GetNavMeshAgent().isStopped) return false;
        
        return Vector3.Distance(target, companionController.transform.position) > 1f;

        //if (Vector3.Distance(companionController.GetNavMeshAgent().destination, target) < 0.1f)
        //{
        //    return companionController.GetNavMeshAgent().remainingDistance < 0.01f;
        //}    
        //else
        //{
        //    return false;
        //}
            
    }

    public MoveCommand(Vector3 position)
    {
        target = position;
    }
}
