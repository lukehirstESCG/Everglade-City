using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        // Is the player moving? If yes, then do these bits.
        if (direction.magnitude >= 0.01f)
        {
            // Plays walking sound
            FindObjectOfType<AudioManager>().Play("Walking");
            anim.SetBool("isWalking", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

        // Is the player NOT moving? If yes, then do this.
        else if (direction.magnitude <= 0f)
        {
            // Stops Walking sound
            anim.SetBool("isWalking", false);
            FindObjectOfType<AudioManager>().Stop("Walking");
        }
        // Is the player pressing a shift key? If so, double the speed.
        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetKey(KeyCode.RightShift)))
        {
            // PLays running sound, and stops walking sound
            FindObjectOfType<AudioManager>().Play("Running");
            FindObjectOfType<AudioManager>().Stop("Walking");

            // double the speed of the inital speed variable.
            runSpeed = speed * 2;
            anim.SetBool("isRunning", true);
            Debug.Log("Target is running at: " + runSpeed);
        }
        // Has the player stopped pressing a shift key? If so, return the animation to walking.
        else
        {
            // Stops the running sound, and plays the walking sound.
            FindObjectOfType<AudioManager>().Stop("Running");
            FindObjectOfType<AudioManager>().Play("Walking");

            // Sets the animation back to walking.
            anim.SetBool("isRunning", false);
        }
    }
}
