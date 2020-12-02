using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    //Respawns ball when ball has gone out of bounds
    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.GetComponent<Ball>().Respawn();
    }
}
