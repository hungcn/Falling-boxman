using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBound : MonoBehaviour
{
    public float minX = -2.58f, maxX = 2.58f, minY = -5.6f, maxY = 5.6f;
    private bool outOfBound;

    // Update is called once per frame
    void Update()
    {
        CheckBound();
    }

    void CheckBound()
    {
        Vector2 tmp = transform.position;

        if (tmp.x > maxX) tmp.x = maxX;
        if (tmp.x < minX) tmp.x = minX;
        transform.position = tmp;
        
        if (tmp.y <= minY) {
            if (!outOfBound)
            {
                outOfBound = true;
                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "TopSpike")
        {
            transform.position = new Vector2(1000f, 1000f);
            SoundManager.instance.DeathSound();
            GameManager.instance.RestartGame();
        }
    }
}
