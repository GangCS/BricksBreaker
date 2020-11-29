using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject balls;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void instatiateBalls()
    {
        if (balls != null)
        {
            GameObject ball1 = Instantiate(balls, new Vector3(transform.position.x + transform.localScale.x, transform.position.y), Quaternion.identity);
            GameObject ball2 = Instantiate(balls, new Vector3(transform.position.x + transform.localScale.x, transform.position.y + transform.localScale.y), Quaternion.identity);
            GameObject ball3 = Instantiate(balls, new Vector3(transform.position.x - transform.localScale.x, transform.position.y - transform.localScale.y), Quaternion.identity);
            ball1.GetComponent<Rigidbody2D>().velocity = new Vector3(-7, 3, 0);
            ball2.GetComponent<Rigidbody2D>().velocity = new Vector3(7, 5, 3);
            ball3.GetComponent<Rigidbody2D>().velocity = new Vector3(-3, 4, 1);
            Mover.ballCount += 3;
            //Debug.Log(Mover.ballCount);
        }
    }

}
