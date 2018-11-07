using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MovementDirection {
    RIGHT,
    LEFT
}

public class MarioController : MonoBehaviour {

    private const float LINEAL_SPEED = 70f;
    private const float JUMP_FORCE = 40000;
    private const float DISTANCE_TO_GROUND = 10f;

    public float linealSpeed;
    public float jumpForce;

    private Animator anim;
    public Text scoreLabel;
    private int coin;
    private Rigidbody2D rgbody;
    private MovementDirection movementDirection;

    public LayerMask groundLayer;
        
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isAlive", true);
        anim.SetBool("grounded", true);

        coin = 0;
        scoreLabel.text = "Score : " + coin;
        rgbody = GetComponent<Rigidbody2D>();
        linealSpeed = LINEAL_SPEED;
        jumpForce = JUMP_FORCE;
        movementDirection = MovementDirection.RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimsState();
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

    private void UpdateAnimsState()
    {
        anim.SetFloat("speed", Mathf.Abs(rgbody.velocity.x));
        anim.SetBool("grounded", IsTouchingTheGround());

    }

    public void MueveDerecha() {
        if (movementDirection == MovementDirection.LEFT) {
            GetComponent<SpriteRenderer>().flipX = false;
            movementDirection = MovementDirection.RIGHT;
        }
        //rgbody.velocity = new Vector2(transform.right.x * linealSpeed, transform.right.y);
        rgbody.velocity = new Vector2(transform.right.x * linealSpeed, rgbody.velocity.y);
    }

    public void MueveIzquierda()
    {
        if (movementDirection == MovementDirection.RIGHT)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            movementDirection = MovementDirection.LEFT;
        }
        rgbody.velocity = new Vector2(-(transform.right.x * linealSpeed), rgbody.velocity.y);
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
            AddCoin();
        }
    }

    private void AddCoin()
    {
        coin++;
        scoreLabel.text = "Score : " + coin;
    }
}
