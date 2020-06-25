using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float boundY = 5.4f;
    public bool isMovingLeft, isMovingRight, isBreakable, isSpike, isStandard;
    private Animator anim;

    void Awake() {
        if (isBreakable) anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 tmp = transform.position;
        tmp.y += moveSpeed * Time.deltaTime;
        transform.position = tmp;
        
        if (tmp.y >= boundY) Destroy(gameObject);
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.35f); 
    }

    void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player"){
            if (isSpike)
            {
                other.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            if (isBreakable)
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }
            if (isStandard){
                SoundManager.instance.LandSound();
            }
        }
    }

    void OnCollisionStay2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            if (isMovingLeft)
                other.gameObject.GetComponent<PlayerMove>().PlatformMove(-2f);
            if (isMovingRight)
                other.gameObject.GetComponent<PlayerMove>().PlatformMove(2f);
        }
    }
}
