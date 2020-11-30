using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameStartGame : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int x = Random.Range(0, 20);
        rb.AddForce(new Vector2(x, 20), ForceMode2D.Impulse);
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
