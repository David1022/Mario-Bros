using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection {
    RIGHT,
    LEFT
}

public class CharacterController : MonoBehaviour {

    public float velocidadRotacion;
    public float velocidadLineal;
    public float jumpForce;
    private Rigidbody2D rgbody;
    private MovementDirection movementDirection;

    public LayerMask groundLayer;
        
	// Use this for initialization
	void Start () {
        rgbody = GetComponent<Rigidbody2D>();
        velocidadRotacion = 50f;
        velocidadLineal = 0.7f;
        jumpForce = 400f;
        movementDirection = MovementDirection.RIGHT;
    }

    public void MueveDerecha() {
        if (movementDirection == MovementDirection.LEFT) {
            GetComponent<SpriteRenderer>().flipX = false;
            movementDirection = MovementDirection.RIGHT;
        }
        rgbody.velocity = new Vector2(transform.right.x * velocidadLineal, transform.right.y);
    }

    public void MueveIzquierda()
    {
        if (movementDirection == MovementDirection.RIGHT)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            movementDirection = MovementDirection.LEFT;
        }
        rgbody.velocity = new Vector2(-(transform.right.x * velocidadLineal), transform.right.y);
    }

    public void RotaDerecha()
    {
        //rigidbody.AddForce(Vector2.right, ForceMode2D.Force);
        rgbody.MoveRotation(rgbody.rotation - velocidadLineal * Time.deltaTime);
    }

    public void RotaIzquierda()
    {
        rgbody.MoveRotation(rgbody.rotation + velocidadLineal * Time.deltaTime);
    }

    public void Jump() {
        if (IsTouchingTheGround())
        {
            rgbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsTouchingTheGround()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer)) {
            return true;
        } else {
            return false;
        }
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            MueveIzquierda();

        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            MueveDerecha();
        } else {
        }if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Jump();
        } else {

        }
    }
    private void FixedUpdate()
    {
        //if (rigidbody.velocity.x < velocidadLineal) {
          //  rigidbody.velocity = new Vector2(velocidadLineal, rigidbody.velocity.y);
        //}
    }
}
