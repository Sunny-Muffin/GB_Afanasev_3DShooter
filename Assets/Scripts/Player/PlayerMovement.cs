using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float runSpeed = 15f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;


    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundLayer;


    private Vector3 velocity;
    private bool isGrounded;
    private bool isRunning;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Running = "Running";

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, 0.4f, groundLayer);
        /*
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // можно 0, но -2 лучше
        }
        */

        float x = Input.GetAxis(Horizontal);
        float z = Input.GetAxis(Vertical);
        isRunning = Input.GetButton(Running);

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * (isRunning ? runSpeed : speed) * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            Debug.Log("JUMPING!");
            //velocity.y = Mathf.Sqrt(jumpHeight * -gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }

    
}
