using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float force;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.lifes > 0)
        {
            transform.Translate(GameManager.currentSpeed * Time.deltaTime, 0, 0);
        }
    }

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Obstacle" || collision.collider.tag == "Platform")
    //    {
    //        Destroy(collision.collider.gameObject);
    //        GameManager.score += 10;
    //    }
    //}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            GameManager.score += 10;
        }
        if (collision.tag == "Platform")
        {
            Destroy(collision.gameObject);
        }
    }
}
