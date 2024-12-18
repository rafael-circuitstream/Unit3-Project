using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Directional Inputs
    [SerializeField] private Vector2 lookDirection;
    [SerializeField] private Vector3 moveDirection;

    //Reference to the controller
    [SerializeField] private CharacterController controller;
    //Reference to the Head/Camera GameObject
    [SerializeField] private Camera head;

    [SerializeField] private float mouseSensitivity;

    //Movement Settings
    [SerializeField] private float movementSpeed;

    //Gravity and Jumping Settings
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityForce;

    [SerializeField] private LayerMask groundLayer;

    [Header("Shooting Settings")]
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private float shootingForce;
    void Start()
    {
        //Control of Mouse Cursor
        Cursor.visible = false; //Visibility to hidden
        Cursor.lockState = CursorLockMode.Locked; //Locked to the center of the screen
    }


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

        Vector3 movementVector = (forwardMovement + sidewaysMovement);


        bool isOnGround = Physics.CheckSphere(transform.position, 0.01f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            gravityForce = jumpForce;
            isOnGround = false;
        }

        controller.Move(movementVector * Time.deltaTime * movementSpeed);
        

        //Gravity is handled here
        if (!isOnGround)
        {
            //Adding constant gravity every second 
            gravityForce += -10f * Time.deltaTime;
            //Apply that movement per second
            controller.Move(Vector3.up * gravityForce * Time.deltaTime);
        }
        else
        {
            //Reset gravity once we get to the floor
            gravityForce = 0;
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            Rigidbody clonedRigidbody = Instantiate(projectilePrefab, weaponTip.position, weaponTip.rotation);
            clonedRigidbody.AddForce(weaponTip.forward * shootingForce);
        }
    }

    //Testing the sphere location
    private void OnDrawGizmos()
    {
        //Drawing a sphere right at the feet of the player
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
