using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //SINGLETON PATTERN
    public static PlayerInput Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //SINGLETON PATTERN

    [SerializeField] private MoveAbility moveAbility;
    [SerializeField] private LookAbility lookAbility;
    [SerializeField] private ShootingAbility shootAbility;
    [SerializeField] private JumpAbility jumpAbility;
    [SerializeField] private InteractAbility interactAbility;
    [SerializeField] private CommanderAbility commandAbility;

    //Directional Inputs
    private Vector2 lookDirection;

    //Reference to the Head/Camera GameObject


    [SerializeField] private float mouseSensitivity;




    void Start()
    {
        GetComponent<HealthSystem>().OnDead += () => 
        {
            this.enabled = false;
        };

        //Control of Mouse Cursor
        Cursor.visible = false; //Visibility to hidden
        Cursor.lockState = CursorLockMode.Locked; //Locked to the center of the screen
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpAbility.Jump();

        }

        if (moveAbility != null)
        {
            Vector3 moveDir = new Vector3();
            moveDir.x = Input.GetAxis("Horizontal");
            moveDir.z = Input.GetAxis("Vertical");
            moveAbility.Move(moveDir);
        }

        if(lookAbility)
        {
            lookDirection.x += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
            lookDirection.y += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

            float angleOnY = lookDirection.y;
            lookDirection.y = Mathf.Clamp(angleOnY, -80, 80);

            lookAbility.Look(lookDirection);
        }

        if (shootAbility != null && Input.GetMouseButtonDown(0))
        {
            shootAbility.Shoot();
        }

        if(interactAbility && Input.GetKeyDown(KeyCode.F))
        {
            interactAbility.Interact();
        }

        if(commandAbility && Input.GetMouseButtonDown(1))
        {
            commandAbility.Command();
        }
    }

}
