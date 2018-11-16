using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionCoinController : MonoBehaviour {

    SpriteRenderer sr;
    public Sprite questionBrick;
    public Sprite emptyQuestionBrick;
    public bool consumed;

    public GameObject coin;

    // Use this for initialization
    void Start()
    {
        consumed = false;
        sr = GetComponentInParent<SpriteRenderer>();
        sr.sprite = questionBrick;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!consumed)
        {
            consumed = true;
            CreateCoin(gameObject.transform);
            transform.parent.GetComponent<QuestionCollisionDetected>().OnCollisionDetected();
        }
    }

    void CreateCoin(Transform transform)
    {
        Instantiate(coin, transform.position + new Vector3(0, 16, 0), transform.rotation);
        InvokeRepeating("DestroyCoin", 1f, 2f);
    }

    public void ChangeImage()
    {
        sr.sprite = emptyQuestionBrick;
    }

    private void DestroyCoin()
    {
        Destroy(coin);
    }

}
