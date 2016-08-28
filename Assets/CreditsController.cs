using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CreditsController : MonoBehaviour {
    public Image image;

    // Use this for initialization
    void Start () {
        image.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void onQuit()
    {
        Application.Quit();
    }
}
