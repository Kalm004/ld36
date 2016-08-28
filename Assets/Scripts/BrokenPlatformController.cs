using UnityEngine;
using System.Collections;

public class BrokenPlatformController : MonoBehaviour {
    public float minForceX;
    public float maxForceX;
    public float minForceY;
    public float maxForceY;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Rigidbody2D childrb = child.gameObject.GetComponent<Rigidbody2D>();
            childrb.AddForce(new Vector2(Random.Range(minForceX, maxForceX), Random.Range(minForceY, maxForceY)), ForceMode2D.Impulse);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
