using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float velocidadLineal;
    private Rigidbody2D rgbody;

    public LayerMask groundLayer;
            
	// Use this for initialization
	void Start () {
        rgbody = GetComponent<Rigidbody2D>();
        velocidadLineal = 0.3f;
    }

    // Update is called once per frame
    void Update () {

    }

    private void FixedUpdate()
    {
        rgbody.velocity = new Vector2(velocidadLineal, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D point = collision.GetContact(0);
        velocidadLineal = (-1) * velocidadLineal;
        collision.otherCollider.CompareTag("Player");
    }
}
