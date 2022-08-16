using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("For Rigidbody")]
    [SerializeField] private float speedRB = .1f;
    [SerializeField] private float runSpeedRB = .2f;
    [SerializeField] private float jumpForce = 20f;
    [Space(10)]

    [Header("For Character controller")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float runSpeed = 15f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float jumpHeight = 10f;
    [Space(10)]

    [SerializeField] private bool useRigidbody = false;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundLayer;


    private Vector3 velocity;
    private bool isGrounded;
    private bool isRunning;
    private Rigidbody rb;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Running = "Running";

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, 0.6f, groundLayer);
        isRunning = Input.GetButton(Running);

        float x = Input.GetAxis(Horizontal);
        float z = Input.GetAxis(Vertical);
        Vector3 move = transform.right * x + transform.forward * z;

        // через ригидбоди двигаться очень неудобно, сделал только потому что это было в домашке
        if (useRigidbody)
        {
            rb.AddForce(move * (isRunning ? runSpeedRB : speedRB), ForceMode.Impulse);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
        else
        {
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; // можно 0, но -2 лучше
            }

            controller.Move(move * (isRunning ? runSpeed : speed) * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }


    }

    
}
