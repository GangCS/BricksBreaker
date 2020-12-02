using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    bool startGame;
    private Rigidbody2D rb;
    [SerializeField] int RandomArcRange = 20;
    [SerializeField] int InitUpBallPower = 12;
    void Start()
    {
        startGame = true;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                int RandomArc = Random.Range(-RandomArcRange, RandomArcRange);
                rb.AddForce(new Vector2(RandomArc, InitUpBallPower),ForceMode2D.Impulse);
                startGame = false;
                transform.parent = null;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Here");
        if (collision.gameObject.tag.CompareTo("LeftWall") == 0 || collision.gameObject.tag.CompareTo("RightWall") == 0)
        {
            
            // if the ball collided left or right wall
            // if its y is 0 then give him boost to y
            if (rb.velocity.y == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0.7f);
            }
        }
    }
}
