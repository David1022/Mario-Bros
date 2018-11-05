using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioFollower : MonoBehaviour {

    public Transform mario;
    private const float INITIAL_X_OFFSET = 0f; // Offset X inicial para que no se vea el inicio de la partida
    private const float Y_OFFSET = 100f; // Offset para que la cámara se mantenga fija a una altura aunque se mueva el jugador

    void Start()
    {
        Vector3 destination = mario.position - Vector3.forward * 10;
        transform.position = new Vector3(INITIAL_X_OFFSET, Y_OFFSET, destination.z);
    }

    // Update is called once per frame
    void Update () {
        //Vector3 destination = mario.position - Vector3.forward * 10;
        //transform.position = new Vector3(destination.x, Y_OFFSET, destination.z);
    }
}
