using UnityEngine;
using System.Collections;

public class FallingController : MonoBehaviour
{
    public Transform player;
    public GameObject destroyable;
    public float playerDistance;
    private Renderer renderer;
    private Rigidbody2D rigidbody2d;
    private PlayerController playerController;
    
    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        playerController = player.gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody2d.isKinematic && player.position.x + playerDistance > transform.position.x)
        {
            rigidbody2d.isKinematic = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.shaking = true;
        //Destroy(gameObject);
        renderer.enabled = false;
        Destroy(GetComponent<BoxCollider2D>());
        destroyable.SetActive(true);
    }
}
