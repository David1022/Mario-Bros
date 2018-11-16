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
        sr = GetComponentInParent<SpriteRenderer>();
        sr.sprite = questionBrick;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!consumed)
        {
            consumed = true;
            CreateSuperMushroom(gameObject.transform);
            transform.parent.GetComponent<QuestionCollisionDetected>().OnCollisionDetected();
        }
    }

    private void CreateSuperMushroom(Transform transform)
    {
        Instantiate(superMushroom, transform.position + new Vector3(0, 16, 0), transform.rotation);
    }

    public void ChangeImage()
    {
        sr.sprite = emptyQuestionBrick;
    }

}
