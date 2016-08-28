using UnityEngine;
using System.Collections;

public class OneUpController : MonoBehaviour {
    public float oneUpTreshold;

    // Use this for initialization
    void Start () {
	if (GameManager.lifes >= GameManager.maxLifes || Random.Range(0f, 1f) > oneUpTreshold)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
