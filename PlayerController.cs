using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float moveinput;
    private Rigidbody2D rb;
    private bool facingright = true;
    private bool isgrounded;
    public Transform groundcheck;
    public float cheackradius;
    public LayerMask whatisground;
    private int extrajumps;
    public int extrajumpsvalue;
    // Start is called before the first frame update
    void Start()
    {
        extrajumps = extrajumpsvalue;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isgrounded == true)
        {
            extrajumps = extrajumpsvalue;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && extrajumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extrajumps--;
        }else if (Input.GetKeyDown(KeyCode.UpArrow) && extrajumps == 0 && isgrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(groundcheck.position, cheackradius, whatisground);
        moveinput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);
        if (facingright == false && moveinput > 0)
        {
            flip();
        } else if (facingright == true && moveinput < 0)
        {
            flip();
        }
    }

    // to flip the player face when change the move direction
    void flip()
    {
        facingright = !facingright;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

}
