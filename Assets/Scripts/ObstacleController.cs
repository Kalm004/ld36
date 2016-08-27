using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private bool destroyed;
    private float destroyedTime;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyed && Time.time > (destroyedTime + 0.33f))
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            rb.Sleep();
            animator.SetBool("destroyed", true);
            destroyed = true;
            destroyedTime = Time.time;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            rb.Sleep();
            animator.SetBool("destroyed", true);
            destroyed = true;
            destroyedTime = Time.time;
        }
    }
}
