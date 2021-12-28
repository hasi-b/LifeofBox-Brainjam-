using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask ground;
    

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.velocity = new Vector2(Input.GetAxis("Horizontal")*speed*Time.deltaTime*50,rb.velocity.y);
        if ((Input.GetKey(KeyCode.Space)) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpSpeed/3);
            SoundManager.PlaySound("jump");
            
        }
        
    }

    bool isGrounded()
    {

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,Vector2.down,0.1f,ground);

        return raycastHit.collider != null;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "moving")
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag== "moving")
        {
            this.transform.parent = null;
        }
    }

}
