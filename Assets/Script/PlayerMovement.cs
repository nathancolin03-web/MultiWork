using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector2 movement;

    public float moveSpeed = 1f;

    public Animator animator;

    public SpriteRenderer sr;

    public float AttackCoolDown = 1f;

    private bool canAttack = true;

   


    void Start()
    {
        StartCoroutine("StartGame");
    }


    void Update()
    {
        rb.linearVelocity = new Vector2(movement .x * moveSpeed, movement.y * moveSpeed);
        animator.SetFloat("InputX",movement.x);
        animator.SetFloat("InputY",movement.y);

        

    }

    public void Move(InputAction.CallbackContext context)
    {
        
        animator.SetBool("IsRuning", true);

        if (context.canceled)
        {
            animator.SetFloat("LastInputX", movement.x);
            animator.SetFloat("LastInputY", movement.y);
         
            animator.SetBool("IsRuning", false);

        }

        movement.x = context.ReadValue<Vector2>().x;
        movement.y = context.ReadValue<Vector2>().y;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && canAttack)
        {
            animator.SetTrigger("Attack");
            StartCoroutine("CoolDown");
        }
    }

    IEnumerator StartGame() 
    {
        animator.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        yield return new WaitForSeconds(15f);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator.enabled = true;

    }

    IEnumerator CoolDown()
    {
        canAttack = false;
        yield return new WaitForSeconds(AttackCoolDown);
        canAttack = true;


    }

}
