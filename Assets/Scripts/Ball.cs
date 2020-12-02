using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public GameObject paddle; //reference to player object

    private Rigidbody2D rb;
    private bool isActive; //true if ball has been released
    private Vector3 ballPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isActive = false;
        ballPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //On button press, release ball upwards and set as active
        if (Input.GetButtonDown("Jump"))
        {
            if (!isActive)
            {
                float horizontalForce = Random.Range(-1, 1) * 10 * speed;
                rb.AddForce(new Vector2(horizontalForce, 50.0f * speed));
                isActive = true;
            }
        }

        //if ball is is not active it will follow the player object
        if(!isActive && paddle != null)
        {
            ballPosition.x = paddle.transform.position.x;
            transform.position = ballPosition;
        }
    }

    //Executes when ball goes out of bounds - see Bounds script
    public void Respawn()
    {
        isActive = false;
        transform.position = ballPosition;
    }

    //Controls the collision of the ball with the paddle
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Paddle")
        {
            float xDir = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 x = new Vector2(xDir, 1).normalized;
            rb.velocity = x * speed;
        }
    }

    //Controls the direction of the ball when colliding with the paddle
    private float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }
}
