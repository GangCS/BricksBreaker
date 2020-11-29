using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterScript : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] float TimeOfPowerUp = 3f;
    Mover m;
    private bool touched = false;
    private GameObject theBall;
    private float SpeedTime;
    private Rigidbody2D rb;
    private bool TouchedOnce=false;
    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.Find("Ball");
        m = GameObject.Find("Cube").GetComponent<Mover>();
        rb = theBall.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag.CompareTo("Player") == 0 && !TouchedOnce)
        {
            this.gameObject.transform.localScale *= 0;
            rb.velocity *= 1.2f;
            m.HigherSpeed(1.2f);
            this.gameObject.transform.position = new Vector3(100, 0, 0);
            SpeedTime = Time.time;
            touched = true;
            TouchedOnce = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (touched)
        {
            if (Time.time - SpeedTime >= TimeOfPowerUp)
            {
                touched = false;
                rb.velocity /= 1.2f;
                m.slowerSpeed(1.2f);
                Destroy(this.gameObject);
            }

        }
    }
}
