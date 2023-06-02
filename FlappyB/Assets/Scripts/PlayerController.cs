using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.velocity = Vector2.up * 5f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == GameData.Default.obstacleTag)
        {
            PlayManager.Default.EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == GameData.Default.scoreTag)
        {
            PlayManager.Default.IncreaceScore();
        }
    }
}
