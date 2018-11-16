using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int time;
    public int score;
    public int coin;

    public Text timeLabel;
    public Text scoreLabel;
    public Text coinLabel;

    public const int ENEMY_DEATH_SCORE = 100;
    public const int COIN_SCORE = 10;
    public const int MUSHROOM_SCORE = 500;
    public const int LEVEL_FINAL_SCORE = 1000;

    public QuestionMushroomController mushroomController;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        mushroomController = GetComponent<QuestionMushroomController>();

        time = 0;
        score = 0;
        coin = 0;

        timeLabel.text = "Time : " + time + " s";
        scoreLabel.text = "Score : " + score;
        coinLabel.text = "Coin : " + coin;

        InvokeRepeating("Chrono", 1f, 1f);
    }

    void Chrono() {
        time++;
        timeLabel.text = "Time : " + time + " s";
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreLabel.text = "Score : " + score;
    }

    public void AddCoin()
    {
        coin++;
        coinLabel.text = "Coin : " + coin;
    }

    // Update is called once per frame
    void Update () {
    }
}
