using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public Animator anim;
    public Transform cam;
    public float speed = 6f;
    private float runSpeed = 12f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.01f)
        {
            FindObjectOfType<AudioManager>().Play("Walking");
            anim.SetBool("isWalking", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(transform.position + moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalking", false);
            FindObjectOfType<AudioManager>().Stop("Walking");
        }

        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetKey(KeyCode.RightShift)))
        {
            FindObjectOfType<AudioManager>().Play("Running");
            FindObjectOfType<AudioManager>().Stop("Walking");
            runSpeed = speed * 2;
            anim.SetBool("isRunning", true);
            Debug.Log("Target is running at: " + runSpeed);
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("Running");
            FindObjectOfType<AudioManager>().Play("Walking");
            anim.SetBool("isRunning", false);
        }
    }
}
