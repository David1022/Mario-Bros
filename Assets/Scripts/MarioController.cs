using System;
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

    public float linealSpeed;
    public float jumpForce;
    public bool isAlive;

    private Animator anim;
    private Rigidbody2D rgbody;
    private AudioSource audio;
    public AudioClip coinAudio;
    public AudioClip jumpAudio;
    public AudioClip powerUpAudio;
    public AudioClip killEnemyAudio;

    private MovementDirection movementDirection;

    public LayerMask groundLayer;

    public GameObject superMushroom;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isAlive", true);
        anim.SetBool("grounded", true);
        isAlive = true;

        //scoreLabel.text = "Score : " + GameManager.coin;
        rgbody = GetComponent<Rigidbody2D>();

        audio = GetComponent<AudioSource>();
        //coinAudio = audio[0];
        //jumpAudio = audio[1];

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
            audio.PlayOneShot(jumpAudio);
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
            audio.PlayOneShot(coinAudio);
            Destroy(collision.gameObject);
            AddCoin();
        } else if (collision.CompareTag("SuperMushroom"))
        {
            TakeSuperMushroom(collision.gameObject);
        }
    }

    private void TakeSuperMushroom(GameObject gameObject)
    {
        audio.PlayOneShot(powerUpAudio);
        GameManager.instance.AddScore(GameManager.MUSHROOM_SCORE);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.collider.CompareTag("EnemyBoxCollider"))
            {
                audio.PlayOneShot(killEnemyAudio);
                GameManager.instance.AddScore(GameManager.ENEMY_DEATH_SCORE);
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
        else if (collision.collider.CompareTag("FinalLevel"))
        {
            GameWon();
        }
        else if (collision.collider.CompareTag("SuperMushroom"))
        {
            TakeSuperMushroom(collision.gameObject);
        }
        else if (collision.collider.CompareTag("BrickBottomCollider"))
        {
        }
    }

    private void CreateSuperMushroom(Transform transform)
    {
        Instantiate(superMushroom, transform.position + new Vector3(0,16,0), transform.rotation);
    }

    private void AddCoin()
    {
        GameManager.instance.AddCoin();
        GameManager.instance.AddScore(GameManager.COIN_SCORE);
    }

    private void GameOver()
    {
        isAlive = false;
        anim.SetBool("isAlive", isAlive);
        //SaveLoad.Save("", "", "");
        SaveLoad.Save(GameManager.instance.time.ToString(), GameManager.instance.score.ToString(), GameManager.instance.coin.ToString());
        SceneManager.LoadScene(SCREEN_TO_OPEN);
    }

    private void GameWon() 
    {
        SaveLoad.Save(GameManager.instance.time.ToString(), GameManager.instance.score.ToString(), GameManager.instance.coin.ToString());
        SceneManager.LoadScene(SCREEN_TO_OPEN);
    }
}
