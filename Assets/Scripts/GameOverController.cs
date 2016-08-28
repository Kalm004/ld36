using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainScene");
            //GameManager.restart();
            //gameObject.SetActive(false);
        }
	}
}
