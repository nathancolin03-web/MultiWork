using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector2 movement;

    public float moveSpeed = 1;

    public Animator animator;

    public SpriteRenderer sr;


    void Start()
    {
        
    }


    void Update()
    {
        rb.linearVelocity = new Vector2(movement .x * moveSpeed, movement.y * moveSpeed);
        animator.SetFloat("Speed",movement.sqrMagnitude);

        if (movement.x != 0)
        {
            if(movement.x < 0)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement.x = context.ReadValue<Vector2>().x;
        movement.y = context.ReadValue<Vector2>().y;

    }
}
