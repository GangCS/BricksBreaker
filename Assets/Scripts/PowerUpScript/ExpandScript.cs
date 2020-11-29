using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandScript : MonoBehaviour
{
    [SerializeField] GameObject Cube;
    [SerializeField] float TimeOfPowerUp = 3f;
    private bool touched = false;
    private Vector3 orginalScale;
    private GameObject theCube;
    static float ExapndTime;
    // Start is called before the first frame update
    void Start()
    {
        orginalScale = Cube.transform.localScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag.CompareTo("Player") == 0)
        {
            this.gameObject.transform.localScale *=0;
            this.gameObject.transform.position = new Vector3(100,0,0);
            collision.gameObject.transform.localScale = orginalScale * 1.3f;
            theCube = collision.gameObject;
            ExapndTime = Time.time;
            touched = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(touched)
        {
            if (Time.time - ExapndTime >= TimeOfPowerUp)
            {
                touched = false;
                theCube.transform.localScale = orginalScale;
                Destroy(this.gameObject);
            }

        }
    }
}
