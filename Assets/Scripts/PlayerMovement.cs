using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float rotationSpeed;

    private float runSpeed;

    [SerializeField]
    private Transform cameraTransform;

    private Animator anim;
    private CharacterController characterController;

    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection = Quaternion.AngleAxis(cameraTransform.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        characterController.SimpleMove(movementDirection * magnitude);

        if (movementDirection != Vector3.zero)
        {
            anim.SetBool("isWalking", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.LeftShift) || (Input.GetKey(KeyCode.RightShift)))
        {
            runSpeed = speed * 2;
            anim.SetBool("isRunning", true);
            Debug.Log("Target is running at: " + runSpeed);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    
    }
        private void OnApplicationFocus(bool focus)
        {
            if (focus)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
