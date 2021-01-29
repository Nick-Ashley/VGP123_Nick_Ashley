using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    public bool isFire;
    private Vector3 initialScale;
    public bool isCape;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        initialScale = transform.localScale;

        if (speed <= 0)
        {
            speed = 5.0f;
        }
        if (jumpForce <= 0)
        {
            jumpForce = 100;

        }
        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.01f;
        }
        if (!groundCheck)
        {
            Debug.Log("Groundcheck does not exist, please set a transfor value for groundcheck");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }
        if (Input.GetButtonDown("Fire1") )
        {
            isFire = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isFire = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
        if (Input.GetButtonDown("Jump") && Input.GetKeyDown(KeyCode.W))
        {
            isCape = true;

        }
        if (Input.GetButtonUp("Jump") && Input.GetKeyUp(KeyCode.W))
        {
            isCape = false;

        }



        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(horizontalInput));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isFire", isFire);
        anim.SetBool("isCape", isCape);
    }
}
