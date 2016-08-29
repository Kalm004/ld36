using UnityEngine;
using System.Collections;

public class DeleteAwayFromTarget : MonoBehaviour {
    public Transform target;
    public float distance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (target.position.x - transform.position.x > distance)
        {
            Destroy(gameObject);
        }
    }
}
