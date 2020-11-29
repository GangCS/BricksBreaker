using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallScript : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] float TimeOfPowerUp = 3f;
    private bool touched = false;
    private Vector3 orginalScale;
    private GameObject theBall;
    static float BallTime;
    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.Find("Ball");
        orginalScale = Ball.transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.CompareTo("Player") == 0)
        {
            this.gameObject.transform.localScale *= 0;
            theBall.transform.localScale = orginalScale * 2f;
            this.gameObject.transform.position = new Vector3(100, 0, 0);
            BallTime = Time.time;
            touched = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(touched)
        {
            if (Time.time - BallTime >= TimeOfPowerUp)
            {
                touched = false;
                theBall.transform.localScale = orginalScale;
                Destroy(this.gameObject);
            }

        }
    }
}
