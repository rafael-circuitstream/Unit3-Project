using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private PhysicalButton doorButton;

    // Start is called before the first frame update
    void Start()
    {
        if(doorButton != null) doorButton.OnPressed.AddListener(OpenDoor);

    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }

    public void CloseDoor()
    {
        gameObject.SetActive(true);
    }
}
