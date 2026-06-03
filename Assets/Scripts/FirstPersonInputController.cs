using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonInputController : MonoBehaviour
{
    public Transform cameraTransform;
    public float moveSpeed = 4f;
    public float lookSensitivity = 0.12f;
    public float gravity = -20f;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private float verticalVelocity;
    private float cameraPitch;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        Look();
    }

    public void OnMove(InputValue value) => moveInput = value.Get<Vector2>();
    public void OnLook(InputValue value) => lookInput = value.Get<Vector2>();

    public void OnJump(InputValue value)
    {
        if (controller.isGrounded)
            verticalVelocity = 7f;
    }

    void Move()
    {
        if (controller.isGrounded && verticalVelocity < 0)
            verticalVelocity = -2f;

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        verticalVelocity += gravity * Time.deltaTime;

        Vector3 velocity = move * moveSpeed;
        velocity.y = verticalVelocity;

        controller.Move(velocity * Time.deltaTime);
    }

    void Look()
    {
        transform.Rotate(Vector3.up * lookInput.x * lookSensitivity);

        cameraPitch -= lookInput.y * lookSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);
    }
}