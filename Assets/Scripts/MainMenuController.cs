using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {
    public Image image;

	// Use this for initialization
	void Start () {
        image.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onPlay()
    {
        SceneManager.LoadScene("History");
    }

    public void onCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void onExit()
    {
        Application.Quit();
    }
}
