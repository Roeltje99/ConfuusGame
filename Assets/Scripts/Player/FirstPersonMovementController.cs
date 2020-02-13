using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonMovementController : MonoBehaviour
{
    private CharacterController characterController;

    [Header("Speed values")]
    public float walkSpeed = 6.0f;
    public float runSpeed = 9.0f;
    public float jumpSpeed = 8.0f;

    [Header("Constraints")]
    public bool allowSprint = true;
    public bool allowJump = true;

    [Header("Optional settings")]
    [Range(0, 100)]
    public float gravity = 20.0f;
    public bool useCameraDirection = true;

    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) ;
            if (useCameraDirection)
            {
                moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            }
            else
            {
                moveDirection = transform.TransformDirection(moveDirection);
            }
            moveDirection.y = 0;

            if (Input.GetButton("Sprint") && allowSprint)
            {
                moveDirection *= runSpeed;
            }
            else
            {
                moveDirection *= walkSpeed;
            }

            if (Input.GetButton("Jump") && allowJump)
            {
                moveDirection.y = jumpSpeed;
            }
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        
        characterController.Move(moveDirection * Time.deltaTime);
    }
}