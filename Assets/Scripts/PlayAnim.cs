using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;

    public bool isGrounded = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float speed = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        animator.SetFloat("Speed", speed);

        animator.SetBool("IsGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetTrigger("Jump");
            isGrounded = false;
        }
    }
}