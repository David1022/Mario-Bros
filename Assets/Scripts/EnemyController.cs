using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private const float LINEAL_SPEED = 40f;

    public float linealSpeed;
    private Rigidbody2D rgbody;

    public LayerMask groundLayer;
            
	// Use this for initialization
	void Start () {
        rgbody = GetComponent<Rigidbody2D>();
        linealSpeed = LINEAL_SPEED;
    }

    // Update is called once per frame
    void Update () {

    }

    private void FixedUpdate()
    {
        rgbody.velocity = new Vector2(linealSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Pipeline") || collision.collider.CompareTag("Start")) {
            linealSpeed = (-1) * linealSpeed;
            if(linealSpeed > 0) {
                GetComponent<SpriteRenderer>().flipX = true;
            } else {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
