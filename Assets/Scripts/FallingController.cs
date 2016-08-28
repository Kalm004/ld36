using UnityEngine;
using System.Collections;

public class FallingController : MonoBehaviour
{
    public Transform player;
    public GameObject destroyable;
    private Renderer renderer;
    private Rigidbody2D rigidbody2d;
    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
        renderer.enabled = false;
        Destroy(GetComponent<BoxCollider2D>());
        destroyable.SetActive(true);
    }
}
