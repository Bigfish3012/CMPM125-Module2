using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Walker : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    CharacterController controller;
    Camera cam;

    float xRotation = 0f;
    Vector3 velocity;
    
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer = -1;
    bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        LookAround();
        Move();
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void Move()
    {
        CheckGrounded();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if ((isGrounded || controller.isGrounded) && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void CheckGrounded()
    {
        Vector3 rayOrigin = transform.position + controller.center;
        float rayDistance = controller.height / 2f + groundCheckDistance;
        
        isGrounded = Physics.Raycast(rayOrigin, Vector3.down, rayDistance, groundLayer);
        
        if (!isGrounded)
        {
            isGrounded = controller.isGrounded;
        }
    }
}
