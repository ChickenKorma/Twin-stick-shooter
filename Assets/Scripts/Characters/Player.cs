using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private float mouseDamping;

    private Movement Movement;

    private Gun GunController;

    private Melee Melee;

    private Camera cam;

    private Transform gun;

    private Animator animator;

    private void Awake()
    {
        // Set up singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        Movement = GetComponent<Movement>();

        Melee = GetComponent<Melee>();

        animator = transform.GetChild(0).GetComponent<Animator>();

        cam = Camera.main;

        gun = transform.GetChild(1);
        GunController = gun.GetComponent<Gun>();
    }

    void Update()
    {
        MovePlayer();

        Quaternion direction = RotateGunToMouse();

        CheckShooting(direction);

        CheckHitting();
    }

    // Gets input from axes and calls function on movement to move the player
    private void MovePlayer()
    {
        Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Movement.Move(movementInput);
    }

    // Find direction to mouse, converts to angle about z axis and rotates gun
    private Quaternion RotateGunToMouse()
    {
        Vector3 worldMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = worldMousePosition - transform.position;

        float targetZRot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float zRot = Mathf.Lerp(gun.rotation.eulerAngles.z, targetZRot, mouseDamping);
        Quaternion rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, zRot));

        gun.rotation = rotation;

        return rotation;
    }

    // Checks mouse input and calls method on gun controller to shoot with precise direction
    private void CheckShooting(Quaternion direction)
    {
        if (Input.GetMouseButton(0))
        {
            GunController.Shoot(direction, true);
        }
    }

    // Checks mouse input and calls method on melee to hit nearby objects
    private void CheckHitting()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Melee.Hit();

            animator.SetTrigger("Hit");
        }
    }
}