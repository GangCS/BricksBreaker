using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasersScript : MonoBehaviour
{
    [SerializeField] float TimeOfPowerUp = 3f;
    private bool touched = false;
    private static float SpeedTime;
    LaserSpawner spawnerA;
    LaserSpawner spawnerB;

    // Start is called before the first frame update
    void Start()
    {
        spawnerA = GameObject.Find("spawnerA").GetComponent<LaserSpawner>();
        spawnerB = GameObject.Find("spawnerB").GetComponent<LaserSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag.CompareTo("Player") == 0)
        {
            this.gameObject.transform.localScale *= 0; // disapper powerUp
            spawnerA.setShotter(true);
            spawnerB.setShotter(true);
            this.gameObject.transform.position = new Vector3(100, 0, 0);
            SpeedTime = Time.time;
            touched = true;
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
                spawnerA.setShotter(false);
                spawnerB.setShotter(false);
                Destroy(this.gameObject);
            }

        }
    }
}
