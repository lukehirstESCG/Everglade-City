using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public States state;
    CharacterController controller;
    public Animator anim;
    public Transform cam;
    public float speed = 6f;
    private float runSpeed = 12f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9f;

    Vector3 velocity;

    float turnSmoothVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        state = States.Idle;
    }

    void Update()
    {
        DoLogic();
    }
    void DoLogic()
    {
        if (state == States.Idle)
        {
            PlayerStanding();
        }
        if (state == States.Walk)
        {
            PlayerWalk();
        }
        if (state == States.Run)
        {
            PlayerRun();
        }
    }
    void PlayerStanding()
    {
        {
            // Are we about to move?
            if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
            {
                state = States.Walk;
            }
        }
    }
    void PlayerWalk()
    {
        {
            if (state == States.Walk)
            {
                state = States.Walk;
            }
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
            state = States.Walk;

            if (direction.magnitude > 0.01f)
            {
                // Plays walking sound
                FindObjectOfType<AudioManager>().Play("Walking");
                anim.SetBool("isWalking", true);

                // Controls the camera
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                controller.Move(moveDir.normalized * speed * Time.deltaTime);
                velocity.y += gravity * Time.deltaTime;

                controller.Move(velocity * Time.deltaTime);

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                   state = States.Run;
                }

            }
            // Stops the character
            if (direction.magnitude <= 0.01f)
            {
                state = States.Idle;
                anim.SetBool("isWalking", false);
                FindObjectOfType<AudioManager>().Stop("Walking");
            }
        }
    }
    void PlayerRun()
    {
        {
            // Plays running sound, and stops walking sound
            FindObjectOfType<AudioManager>().Play("Running");
            FindObjectOfType<AudioManager>().Stop("Walking");

            // double the speed of the inital speed variable.
            runSpeed = speed * 2;
            anim.SetBool("isRunning", true);

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        // Have we released the key?
        if (!Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            // Stops the running sound, and plays the walking sound.
            FindObjectOfType<AudioManager>().Stop("Running");
            FindObjectOfType<AudioManager>().Play("Walking");

            // Sets the animation back to walking.
            anim.SetBool("isRunning", false);
            state = States.Walk;
        }
    }
}