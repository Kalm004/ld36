using UnityEngine;
using System.Collections;

public class DeleteWhenChildNumber : MonoBehaviour {
    public int childThreshold;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.childCount <= childThreshold)
        {
            Destroy(gameObject);
        }
	}
}
