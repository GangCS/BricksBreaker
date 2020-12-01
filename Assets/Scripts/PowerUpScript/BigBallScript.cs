using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallScript : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] float TimeOfPowerUp = 3f;
    [SerializeField] float BallSizeMultiplier = 2f;
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
        if (collision.tag.CompareTo("Player") == 0 && !touched)
        {
            theBall.transform.localScale = orginalScale * BallSizeMultiplier;
            touched = true;  // On trigger could happen more then once per collision so we ensure that the power up will apply only once
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            BallTime = Time.time;
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
