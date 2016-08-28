using UnityEngine;
using System.Collections;

public class OneUpController : MonoBehaviour {
    // Use this for initialization
    void Start () {
	if (GameManager.lifes >= GameManager.maxLifes)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
