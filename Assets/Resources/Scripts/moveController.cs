using UnityEngine;
using UnityEngine.InputSystem;

public class moveController : MonoBehaviour
{
    [SerializeField]
    float moveForce;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    float RaycastFloorCheckLength;
    [SerializeField]
    Rigidbody rigidBody;
    Vector2 moveInput;

    bool jumpInput = false;

    float velocityY = 0;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (!isGrounded()) velocityY += Physics.gravity.y * Time.deltaTime;
        else velocityY = 0;

        if (jumpInput && isGrounded())
        {
            velocityY = jumpForce;
            jumpInput = false;
        }

        Vector3 targetVelocity = transform.TransformDirection(new Vector3(moveInput.x * moveForce, velocityY, moveInput.y * moveForce));
        Vector3 velocityChange = targetVelocity - rigidBody.velocity;
        velocityChange.y = velocityY;

        rigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    bool isGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, RaycastFloorCheckLength)) return true;
        else return false;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        jumpInput = true;
    }

    void OnSlide(InputValue value)
    {

    }
}
