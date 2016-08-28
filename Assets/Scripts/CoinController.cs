using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {
    public float coinTreshold;

	// Use this for initialization
	void Start () {
	    if (Random.Range(0f, 1f) > coinTreshold)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
