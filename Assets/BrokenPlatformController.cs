using UnityEngine;
using System.Collections;

public class BrokenPlatformController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Rigidbody2D childrb = child.gameObject.GetComponent<Rigidbody2D>();
            childrb.AddForce(new Vector2(Random.Range(5f, 10f), Random.Range(1f, 2f)), ForceMode2D.Impulse);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
