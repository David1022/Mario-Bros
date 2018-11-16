using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionCollisionDetected : MonoBehaviour {

    SpriteRenderer sr;
    public Sprite questionBrick;
    public Sprite emptyQuestionBrick;

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = questionBrick;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnCollisionDetected()
    {
        sr.sprite = emptyQuestionBrick;
    }
}
