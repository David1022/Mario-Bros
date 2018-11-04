using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection {
    RIGHT,
    LEFT
}

public class CharacterController : MonoBehaviour {

    private const float LINEAL_SPEED = 100f;
    private const float JUMP_FORCE = 40000;
    private const float DISTANCE_TO_GROUND = 10f;
    public float linealSpeed;
    public float jumpForce;
    private Rigidbody2D rgbody;
    private MovementDirection movementDirection;

    public LayerMask groundLayer;
        
	// Use this for initialization
	void Start () {
        rgbody = GetComponent<Rigidbody2D>();
        linealSpeed = LINEAL_SPEED;
        jumpForce = JUMP_FORCE;
        movementDirection = MovementDirection.RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MueveIzquierda();

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MueveDerecha();
        }
        else
        {
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    }

    public void MueveDerecha() {
        if (movementDirection == MovementDirection.LEFT) {
            GetComponent<SpriteRenderer>().flipX = false;
            movementDirection = MovementDirection.RIGHT;
        }
        rgbody.velocity = new Vector2(transform.right.x * linealSpeed, transform.right.y);
    }

    public void MueveIzquierda()
    {
        if (movementDirection == MovementDirection.RIGHT)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            movementDirection = MovementDirection.LEFT;
        }
        rgbody.velocity = new Vector2(-(transform.right.x * linealSpeed), transform.right.y);
    }

    public void Jump() {
        if (IsTouchingTheGround())
        {
            rgbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsTouchingTheGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, DISTANCE_TO_GROUND, groundLayer)) {
            return true;
        } else {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin")) {
            Destroy(collision.gameObject);
            GameManager.addCoin();
        }
    }
}
