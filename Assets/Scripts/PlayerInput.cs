using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Vector2 lookDirection;
    [SerializeField] private Vector3 moveDirection;

    [SerializeField] private CharacterController controller;
    [SerializeField] private Camera head;

    [SerializeField] private float mouseSensitivity;

    [SerializeField] private float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection.x += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        lookDirection.y += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        float angleOnY = lookDirection.y;
        lookDirection.y = Mathf.Clamp(angleOnY, -80, 80);

        
        head.transform.localRotation = Quaternion.Euler(-lookDirection.y, 0, 0);
        transform.rotation = Quaternion.Euler(0, lookDirection.x, 0);



        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.z = Input.GetAxis("Vertical");

        Vector3 forwardMovement = moveDirection.z * transform.forward;
        Vector3 sidewaysMovement = moveDirection.x * transform.right;


        controller.Move((forwardMovement + sidewaysMovement) * Time.deltaTime * movementSpeed);
 
    }
}
