using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressurePlate : MonoBehaviour, IPuzzlePiece
{
    [SerializeField] private bool unlockWithAnyObject;
    [SerializeField] private Rigidbody[] correctRigidbodies;

    public UnityEvent OnPressureStart = new UnityEvent();
    public UnityEvent OnPressureExit = new UnityEvent();

    protected bool isPressed;
    private void OnTriggerEnter(Collider other)
    {

        foreach (Rigidbody rb in correctRigidbodies)
        {
            if (unlockWithAnyObject || rb == other.attachedRigidbody)
            {
                OnPressureStart?.Invoke();
                isPressed = true;
                return;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {

        foreach (Rigidbody rb in correctRigidbodies)
        {
            if (unlockWithAnyObject || rb == other.attachedRigidbody)
            {
                OnPressureExit?.Invoke();
                isPressed = false;
                return;
            }
        }


        
    }

    //IMPLEMENTATION OF INTERFACE INTO PRESSURE PAD/PLATE
    public bool IsCorrect()
    {
        //isPressed is a simple boolean created in the pressure plate and it says when there is a rigidbody above it
        return isPressed;
    }
}
