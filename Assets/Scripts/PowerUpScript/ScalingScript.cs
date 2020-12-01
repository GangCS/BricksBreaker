using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingScript : MonoBehaviour
{
    [SerializeField] GameObject Cube;
    [SerializeField] float TimeOfPowerUp = 3f;
    [SerializeField] float scalingMult = 1.3f;
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
        
        if (collision.tag.CompareTo("Player") == 0 && !touched)
        {
            
            Vector3 newScale = new Vector3(orginalScale.x * scalingMult, orginalScale.y, orginalScale.z);
            collision.gameObject.transform.localScale = newScale;
            theCube = collision.gameObject;
            ExapndTime = Time.time;
            touched = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
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
