using UnityEngine;
using System.Collections;

public class FallingController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
