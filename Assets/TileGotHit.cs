using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGotHit : MonoBehaviour
{
    [SerializeField] int hitPoints = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitPoints--;
        if(this.hitPoints == 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
