using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
    }

    //Play sound and erase brick upon collision with ball
    private void OnCollisionEnter2D(Collision2D collision)
    {
        soundEffect.Play();
        Destroy(gameObject, 0.1f);
    }
}
