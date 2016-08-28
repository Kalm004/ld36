using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour
{
    public GameObject destroyable;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameObject instance = Instantiate(destroyable);
            instance.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
    }
}
