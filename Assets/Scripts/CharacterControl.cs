using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection {
    RIGHT,
    LEFT
}

public class CharacterControl : MonoBehaviour {

    public float velocidadRotacion;
    public float velocidadLineal;
    public float jumpForce;
    private Rigidbody2D rigidbody;
    private MovementDirection movementDirection;
 
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        velocidadRotacion = 50f;
        velocidadLineal = 1f;
        jumpForce = 400f;
        movementDirection = MovementDirection.RIGHT;
    }

    public void MueveDerecha() {
        if (movementDirection == MovementDirection.LEFT) {
            GetComponent<SpriteRenderer>().flipX = false;
            movementDirection = MovementDirection.RIGHT;
        }
        rigidbody.velocity = new Vector2(transform.right.x * velocidadLineal, transform.right.y);
    }

    public void MueveIzquierda()
    {
        if (movementDirection == MovementDirection.RIGHT)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            movementDirection = MovementDirection.LEFT;
        }
        rigidbody.velocity = new Vector2(-(transform.right.x * velocidadLineal), transform.right.y);
    }

    public void RotaDerecha()
    {
        //rigidbody.AddForce(Vector2.right, ForceMode2D.Force);
        rigidbody.MoveRotation(rigidbody.rotation - velocidadLineal * Time.deltaTime);
    }

    public void RotaIzquierda()
    {
        rigidbody.MoveRotation(rigidbody.rotation + velocidadLineal * Time.deltaTime);
    }

    public void Jump() {
        rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            MueveIzquierda();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MueveDerecha();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            RotaIzquierda();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            RotaDerecha();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        if (rigidbody.velocity.x < velocidadLineal) {
            //rigidbody.velocity = new Vector2(velocidadLineal, rigidbody.velocity.y);
        }
    }
}
