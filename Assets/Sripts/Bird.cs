using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static Bird bird;
    [SerializeField] private float jumpPower = 5;

    bool isJump;
    private void Awake()
    {
        isJump = true;
    }
    private void Start()
    {
        bird = this;
    }

    private void Update()
    {
        if(GameManager.manager.end == false)
        {
            if (Input.GetMouseButtonDown(0) && this.transform.position.y < 5 && isJump == true)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            }
        }
        /*
        하단은 진행 방향에 따라 새 각도 조정하는 부분
        lookDirection.z = this.GetComponent<Rigidbody2D>().velocity.y * 10 + 20;
        Quaternion R = Quaternion.Euler(lookDirection);
        imageBird.transform.rotation = Quaternion.RotateTowards(imageBird.transform.rotation, R, 5);
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cactus")
        {
            iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.2, "y", 0.2, "time", 0.5f));
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);
            isJump = false;
            GameManager.manager.GameOver();
        }
        else if(collision.gameObject.tag == "Score" && GameManager.manager.end == false)
        {
            GameManager.manager.score += 10;
        }
        else if(collision.gameObject.tag == "Dead")
        {
            GameManager.manager.GameOver();
            GameManager.manager.end = true;
        }
    }
}
