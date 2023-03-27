using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    public Transform cam;
    public float speed = 6f;
    public float turnsmoothTime = 0.1f;
    float turnsmoothVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            anim.SetBool("isWalking", true);
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnsmoothVelocity, turnsmoothTime);
            transform.rotation = Quaternion.Euler(0, Angle, 0);

            Vector3 MoveDir = Quaternion.Euler(0f, TargetAngle, 0f) * Vector3.forward;
            controller.Move(MoveDir.normalized * speed * Time.deltaTime);
        }
        else if (direction.magnitude <= 0.1f)
        {
            anim.SetBool("isWalking", false);
        }
    }
}