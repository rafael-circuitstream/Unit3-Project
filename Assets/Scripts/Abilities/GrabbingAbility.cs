using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingAbility : MonoBehaviour
{
    [SerializeField] private Transform holdingHand;

    private Rigidbody objectInHold;

    public void PickUpObject(Rigidbody toGrab)
    {
        if(objectInHold != null)
        {
            DropDownObject();
            return;
        }

        objectInHold = toGrab;
        toGrab.useGravity = false;
        toGrab.isKinematic = true;
        toGrab.transform.position = holdingHand.position;
        toGrab.transform.SetParent(holdingHand, true);
    }

    public void DropDownObject()
    {
        objectInHold.useGravity = true;
        objectInHold.isKinematic = false;
        objectInHold.transform.SetParent(null);
        objectInHold = null;
    }

    public void MoveObject()
    {

    }
}
