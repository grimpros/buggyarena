using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float gravity = 5f;
    [SerializeField] CharacterController characterController;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rigBody;

    Vector3 movement, moveDirection;
    float jumpDir;
    
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
        bool jump = Input.GetKeyDown(KeyCode.Space);

        movement = new Vector3(xAxis, 0, zAxis);
        movement = movement * moveSpeed;
        moveDirection = movement;

        if (characterController.isGrounded)
        {
            jumpDir = -1;
            if (jump)
            {
                jumpDir = jumpForce;
            }
        }

        jumpDir -= gravity * Time.deltaTime;
        moveDirection.y = jumpDir;

        float moveValue = (xAxis != 0f || zAxis != 0f) ? 1f : 0f;
        animator.SetFloat("Move", moveValue);
        Debug.Log(characterController.isGrounded.ToString());
    }

     void FixedUpdate()
     {
         characterController.Move(moveDirection * Time.deltaTime);
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
    
}
