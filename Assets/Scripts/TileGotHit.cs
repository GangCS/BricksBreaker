using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileGotHit : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    [SerializeField] Animator anim;
    [SerializeField] bool isDestroyable;
    [SerializeField] Sprite brokenSprite;
    [SerializeField] int NumberOfTile;
    GameObject TileParent;
    private bool shouldBeBroken = true;

    // Start is called before the first frame update
    void Start()
    { 
        anim.SetFloat("Life", hitPoints);
        anim.SetInteger("TileNum", NumberOfTile);
        anim.SetBool("IsBreakable", isDestroyable);
        if (hitPoints < 2)
        {
            shouldBeBroken = false;
        }
        anim.SetBool("ShouldBeBroken", shouldBeBroken);
        TileParent = this.transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "laser")
        {
            Destroy(this.gameObject); // Destroy Brick
            Destroy(collision.gameObject); // Destroy laser
            if (TileParent.gameObject.transform.childCount == 1 && isDestroyable)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            if (isDestroyable)
            {
                hitPoints--;
                anim.SetFloat("Life", hitPoints);
                if (hitPoints == 1)
                {

                    this.gameObject.GetComponent<SpriteRenderer>().sprite = brokenSprite;
                }
                if (TileParent.gameObject.transform.childCount == 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
