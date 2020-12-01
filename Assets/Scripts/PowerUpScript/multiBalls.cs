using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiBalls : MonoBehaviour
{
    private bool touched = false;
    private ballsSpawnerScript ballsSpawn;
    // Start is called before the first frame update
    void Start()
    {
        ballsSpawn = GameObject.Find("ballsSpawner").GetComponent<ballsSpawnerScript>();
        // instatiateBalls
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !touched)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            ballsSpawn.instatiateBalls();
            touched = true;
        }
    }
}
