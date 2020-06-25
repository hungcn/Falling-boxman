using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D playerBody;
    public float moveSpeed = 3f;
    public float centerX = 0f;

    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        centerX = Screen.width * 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // For moving on PC
        if (Input.GetAxisRaw("Horizontal") < 0f) 
            playerBody.velocity = new Vector2(-moveSpeed, playerBody.velocity.y);
        if (Input.GetAxisRaw("Horizontal") > 0f)
            playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);
        //

        for (int i = 0; i < Input.touchCount; ++i) 
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began) 
            {
                if (touch.position.x < centerX) // move left
                    playerBody.velocity = new Vector2(-moveSpeed, playerBody.velocity.y);
        
                if (touch.position.x > centerX) // move right
                    playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);
            }
        }
    }

    public void PlatformMove(float x)
    {
        playerBody.velocity = new Vector2(x, playerBody.velocity.y);
    }
}
