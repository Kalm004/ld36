using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public Transform target;
    private float lastX;
    private Transform t;

	// Use this for initialization
	void Start () {
        lastX = target.position.x;
        t = transform;
	}
	
	// Update is called once per frame
	void Update () {
        t.Translate(new Vector3(target.position.x - lastX, 0, 0));
        lastX = target.position.x;
    }
}
