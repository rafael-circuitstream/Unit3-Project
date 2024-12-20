using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAbility : MonoBehaviour
{
    [SerializeField] private Transform interactionTip;
    [SerializeField] private LayerMask interactionFilter;

    // Update is called once per frame
    public void Interact()
    {
        Ray customRay = new Ray(interactionTip.position, interactionTip.forward);
        RaycastHit tempHit;

        if (!Physics.Raycast(customRay, out tempHit, 5f, interactionFilter)) return;

        Debug.Log("I hit " + tempHit.collider.name);

        Destroy(tempHit.collider.gameObject);
        Debug.DrawRay(interactionTip.position, interactionTip.forward * 5f, Color.green);
    }

}
