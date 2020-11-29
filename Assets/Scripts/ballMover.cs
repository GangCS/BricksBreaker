using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballMover : MonoBehaviour
{
    [SerializeField] float ballYvelocity = 400f;
    [SerializeField] float ballXvelocity = 100f;

    private Rigidbody2D rb;

    private void Start()
    {
        Vector2 startForce = new Vector2(ballXvelocity, -ballYvelocity);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(startForce);
    }
    private void Update()
    {
      
    }
}
