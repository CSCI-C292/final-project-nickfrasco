using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerSpeed = 12;
    public int playerJumpPower = 1200;
    public bool facingRight = true;
    public float moveX;
    public bool isGrounded;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRaycast();
        
    }

    void PlayerMove(){
        moveX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump")){
            Jump();
        }

        if (moveX < 0.0f && facingRight == false)
           { FlipPlayer (); } 
        else if (moveX > 0.0f && facingRight == true)
           { FlipPlayer (); } 

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX*playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);   
    }

    void Jump() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void PlayerRaycast() {
        RaycastHit2D ray = Physics2D.Raycast (transform.position, Vector2.down);
        if (ray != null && ray.collider != null && ray.distance < 2f && ray.collider.tag == "Enemy") {
            GetComponent<Rigidbody2D>().AddForce (Vector2.up * 1000);
            ray.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right*200);
            ray.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            ray.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            ray.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            ray.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
        }
        if (ray != null && ray.collider != null && ray.distance < 2f && ray.collider.tag != "Enemy") {
            isGrounded = true;

    }
    }
}


