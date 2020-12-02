using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 5f;

    private float input;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        input = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.right * input * speed;
    }
}
