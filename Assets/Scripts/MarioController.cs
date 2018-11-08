﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum MovementDirection {
    RIGHT,
    LEFT
}

public class MarioController : MonoBehaviour {

    private const float LINEAL_SPEED = 70f;
    private const float JUMP_FORCE = 40000;
    private const float DISTANCE_TO_GROUND = 10f;
    private const string SCREEN_TO_OPEN = "FinishScreen";
    private const int COIN_SCORE = 10;

    public float linealSpeed;
    public float jumpForce;
    public bool isAlive;

    private Animator anim;
    //public Text scoreLabel;
    private Rigidbody2D rgbody;
    private AudioSource audio;
    private MovementDirection movementDirection;

    public LayerMask groundLayer;

    public GameObject superMushroom;
    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isAlive", true);
        anim.SetBool("grounded", true);
        isAlive = true;

        //scoreLabel.text = "Score : " + GameManager.coin;
        rgbody = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        linealSpeed = LINEAL_SPEED;
        jumpForce = JUMP_FORCE;
        movementDirection = MovementDirection.RIGHT;
        gameManager = gameObject.GetComponent<GameManager>();
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
            audio.Play();
            Destroy(collision.gameObject);
            AddCoin();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.collider.CompareTag("EnemyBoxCollider"))
            {
                Destroy(collision.gameObject);

            }
            else if (collision.collider.CompareTag("EnemyCircleCollider"))
            {
                GameOver();
            }
        }
        else if (collision.gameObject.CompareTag("DeadZone"))
        {
            GameOver();
        }
        else if (collision.collider.CompareTag("Question"))
        {
            CreateSuperMushroom(collision.collider.GetComponent<Transform>());
        }
        else if (collision.collider.CompareTag("FinalLevel"))
        {
            GameWon();
        }
    }

        private void CreateSuperMushroom(Transform transform)
    {
        Instantiate(superMushroom, transform.position + new Vector3(0,16,0), transform.rotation);
    }

    private void AddCoin()
    {
        gameManager.AddCoin();
        gameManager.AddScore(COIN_SCORE);
        //scoreLabel.text = "Score : " + GameManager.coin;
    }

    private void GameOver()
    {
        isAlive = false;
        anim.SetBool("isAlive", isAlive);
        SaveLoad.Save("", "", "");
        SceneManager.LoadScene(SCREEN_TO_OPEN);
    }

    private void GameWon() 
    {
        SaveLoad.Save(gameManager.time.ToString(), gameManager.scoreLabel.text, gameManager.coinLabel.text);
        SceneManager.LoadScene(SCREEN_TO_OPEN);
    }
}
