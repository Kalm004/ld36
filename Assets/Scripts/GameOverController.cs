using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void onRetry()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void onQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
