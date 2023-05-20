using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 4f;


    [Header("Components")]
    public Rigidbody2D Rb;
    public LayerMask groundLayer;
    [Header("Collision")]
    public bool onGround = false;
    public float groundLine = 2;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.Raycast(transform.position , Vector2.down,groundLine,groundLayer);

        bool space = Input.GetKey(KeyCode.Space);
        bool rightkey = Input.GetKey(KeyCode.RightArrow);
        bool leftkey = Input.GetKey(KeyCode.LeftArrow);

        if(rightkey)
        {
            Debug.Log("Right key Pressed");
            Rb.AddForce(Vector2.right, ForceMode2D.Impulse);
        }

        if (leftkey)
        {
            Debug.Log("Left key Pressed");
            Rb.AddForce(Vector2.left, ForceMode2D.Impulse);
        }

        if(space && onGround)
        {
            Debug.Log("Space key Pressed");
            Rb.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") *runSpeed;

        if (onGround)
        {
            animator.SetBool("isJumping",false);

        }
        else
        {
            animator.SetBool("isJumping" , true);
        }

        animator.SetFloat("speed",Mathf.Abs(horizontalMove));
    }

private void OnDrawGizmos()
{
    Gizmos.color = Color.blue;
    Gizmos.DrawLine(transform.position,transform.position+Vector3.down*groundLine);
}    
}
