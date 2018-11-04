using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static int coin;

	// Use this for initialization
	void Start () {
        coin = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void addCoin() {
        coin++;
    }
}
