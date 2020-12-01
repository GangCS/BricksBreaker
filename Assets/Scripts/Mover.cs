using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour
{
    float playerYposition;
   
    [SerializeField] float newDirectionSize = 10;
    [SerializeField] float newDirectionPower = 12;
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;
    public static int ballCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerYposition = this.transform.position.y;
    }
   public void HigherSpeed(float newMulti)
    {
        this.newDirectionPower = newDirectionPower * newMulti;
    }
    public float getSpeed()
    {
        return newDirectionPower;
    }
    public void slowerSpeed(float newMulti)
    {
        this.newDirectionPower = newDirectionPower / newMulti;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        Vector2 mouseVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseVec.y = playerYposition;
        if(mouseVec.x < leftWall.transform.position.x + (leftWall.transform.localScale.x*2) + this.transform.localScale.x)
        {
            mouseVec.x = leftWall.transform.position.x + (leftWall.transform.localScale.x*2) + this.transform.localScale.x;
        }
        if (mouseVec.x > rightWall.transform.position.x - (rightWall.transform.localScale.x * 2) - this.transform.localScale.x)
        {
            mouseVec.x = rightWall.transform.position.x - (rightWall.transform.localScale.x * 2) - this.transform.localScale.x;
        }
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
        direction = direction.normalized*newDirectionPower;//Set it on permanent speed
        collision.rigidbody.velocity = direction;
    }
}
