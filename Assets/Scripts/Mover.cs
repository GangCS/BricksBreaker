using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    float playerYposition;

    [SerializeField] float newDirectionSize = 10;
    [SerializeField] float newDirectionPower = 20;

    // Start is called before the first frame update
    void Start()
    {
        playerYposition = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseVec.y = playerYposition;
        if (mouseVec.x < -9) { mouseVec.x = -9; }
        if (mouseVec.x >  9) { mouseVec.x =  9; }
        transform.position = mouseVec;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 ballLoc = collision.transform.localPosition;// Cube middle position
        Vector2 cubeLoc = this.transform.localPosition;// Ball middle position

        //compute location of the ball on the brick
        float newDirection = (ballLoc.x - cubeLoc.x)*newDirectionSize;

        Vector2 direction = collision.rigidbody.velocity;
        direction.x = newDirection;
        direction = (direction.normalized)*newDirectionPower;//Set it on permanent speed
        collision.rigidbody.velocity = direction;
    }
}
