using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    bool startGame;
    private Rigidbody2D rb;
    [SerializeField] int RandomArcRange=20;
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
                Destroy(this);
            }
        }
    }
}
