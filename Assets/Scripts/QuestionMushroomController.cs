using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionMushroomController : MonoBehaviour {

    SpriteRenderer sr;
    public Sprite questionBrick;
    public Sprite emptyQuestionBrick;
    public bool consumed;

    public GameObject superMushroom;

    // Use this for initialization
    void Start () {
        consumed = false;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = questionBrick;
	}
	
	// Update is called once per frame
	void Update () {
        if (consumed) {
            sr.sprite = emptyQuestionBrick;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.CompareTag("BrickBottomCollider"))
        {
            consumed = true;
            CreateSuperMushroom(collision.otherCollider.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BrickBottomCollider"))
        {
            consumed = true;
            CreateSuperMushroom(collision.transform);
        }
    }

    private void CreateSuperMushroom(Transform transform)
    {
        Instantiate(superMushroom, transform.position + new Vector3(0, 5, 0), transform.rotation);
    }

}
