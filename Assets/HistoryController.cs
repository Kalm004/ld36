using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class HistoryController : MonoBehaviour {
    public Sprite[] sprites;
    public Image image;

    private int currentImage;
    private float lastChangeTime;
	// Use this for initialization
	void Start () {
        image.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        image.sprite = sprites[currentImage];
        lastChangeTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= lastChangeTime + 2f)
        {
            currentImage++;
            if (currentImage < sprites.Length)
            {
                image.sprite = sprites[currentImage];
                lastChangeTime = Time.time;
            } else
            {
                SceneManager.LoadScene("MainScene");
            }
        }
	}
}
