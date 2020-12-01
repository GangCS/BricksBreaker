using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    bool startGame;
    private Rigidbody2D rb;
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
                int x = Random.Range(0, 20);
                rb.AddForce(new Vector2(x, 12),ForceMode2D.Impulse);
                startGame = false;
                transform.parent = null;
                Destroy(this);
            }
        }
    }
}
