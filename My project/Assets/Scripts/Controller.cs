using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] private LayerMask platformLayerMask;
    public ParticleSystem dust;
    public Rigidbody2D rb;
    public CircleCollider2D col;
    public Animator animator;
    public bool isMenu;
    public Vector3 pos
    {
        get
        {
            return transform.position;
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D> ();
        col = GetComponent<CircleCollider2D> ();
    }

    public void Push(Vector2 force)
    {
        rb.AddForce (force, ForceMode2D.Impulse);
    }

    public void ActivateRb()
    {
        rb.isKinematic = false;
    }

    public void DeactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }

    //Checks to see if player is grounded.
    private bool IsGrounded()
    {
        float extra = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, extra, platformLayerMask);

        // Color rayColor;

        // if (raycastHit.collider != null)
        // {
        //     rayColor = Color.green;
        // }
        // else
        // {
        //     rayColor = Color.red;
        // }
        // Debug.DrawRay(col.bounds.center + new Vector3(col.bounds.extents.x, 0), Vector2.down * (col.bounds.extents.y + extra), rayColor);
        // Debug.DrawRay(col.bounds.center - new Vector3(col.bounds.extents.x, 0), Vector2.down * (col.bounds.extents.y + extra), rayColor);
        // Debug.Log(raycastHit.collider);

        return raycastHit.collider != null;
    }

    void CreateDust(){
        dust.Play();
    }


    //Code that plays when player collides with something.
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        FindObjectOfType<AudioManager>().Play("Splat" + Random.Range(1,4));
        CreateDust();
        // Debug.Log("Collided!");
    }

    void Update()
    {

        //Various checks to the player to play appropriate animation.
        if (IsGrounded() == false)
        {
            animator.SetBool("isGrounded", false);
        }

        else
        {
            animator.SetBool("isGrounded", true);
        }

        animator.SetFloat("Speed", rb.velocity.magnitude);
        // float dirX = Input.GetAxis("Horizontal");
        
        // rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
    }
}
