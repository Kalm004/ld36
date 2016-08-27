using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
    private Transform t;
    private Renderer r;

    // Use this for initialization
    void Start()
    {
        t = transform;
        r = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBecameInvisible()
    {
        //move to new position when invisible
        t.Translate(new Vector3(r.bounds.size.x * 2f, 0, 0));
    }
}
