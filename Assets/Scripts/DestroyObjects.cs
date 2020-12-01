using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObjects : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.tag.CompareTo("ball") == 0)
            {
                Destroy(collision.gameObject);
                Mover.ballCount--;
            //Debug.Log(Mover.ballCount);
            if (noBallsLeft())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            }
            else
            {
                Destroy(collision.gameObject);
            }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private bool noBallsLeft()
    {
        return Mover.ballCount <= 0;
    }
}
