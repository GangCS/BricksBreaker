using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGotHit : MonoBehaviour
{
    [SerializeField] int hitPoints = 1;
    [SerializeField] Animator anim;
    [SerializeField] bool isDestroyable;
    [SerializeField] Sprite brokenSprite;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetFloat("Life", hitPoints);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "laser")
        {
            Destroy(this.gameObject); // Destroy Brick
            Destroy(collision.gameObject); // Destroy laser
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDestroyable)
        {
            hitPoints--;
            anim.SetFloat("Life", hitPoints);
            if (hitPoints==1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = brokenSprite;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
