using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] GameObject laser;
    bool canFire = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject shotter = Instantiate(laser, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
                shotter.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
                    
            }
        }
    }
    public void setShotter(bool canFire)
    {
        this.canFire = canFire;
    }
}
