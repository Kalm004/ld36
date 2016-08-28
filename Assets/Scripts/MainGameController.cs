using UnityEngine;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject coinPrefab;
    public GameObject oneupPrefab;
    public Transform player;
    public float generateInterval;
    public Text scoreText;
    public GameObject gameOver;
    public float minPlatformY = -1.3f;
    public float maxPlatformY = 2;
    public float compoWidth = 40;

    public float lastObstaclePosition = 0;

    private float elapsed = 0.0f;
    Vector3 originalCamPos;
    private float duration = 0.2f;
    private float magnitude = 1f;
    private bool isShaking = false;
    private int lastPrefab = -1;

    public void Awake()
    {
        GameManager.restart();
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.lifes > 0)
        {
            scoreText.text = "Score: " + GameManager.score;
            generateObstacle();
        }
        else
        {
            gameOver.SetActive(true);
        }
        if (!isShaking && GameManager.shaking)
        {
            isShaking = true;
            originalCamPos = Camera.main.transform.position;
        }
        if (!GameManager.shaking)
        {
            isShaking = true;
        }
        if (isShaking)
        {
            //Shake();
        }
    }

    private void generateObstacle()
    {
        if (player.position.x + 10 + compoWidth/2 > lastObstaclePosition)
        {
            int prefabType = lastPrefab;
            while (prefabType == lastPrefab)
            {
                prefabType = Random.Range(0, obstaclePrefabs.Length);
            }
            lastPrefab = prefabType;
            GameObject obstacle = Instantiate(obstaclePrefabs[prefabType]);
            obstacle.transform.position = new Vector3(player.position.x + 20 + compoWidth / 2, obstacle.transform.position.y, 0);
            for (int i = 0; i < obstacle.transform.childCount; i++)
            {
                Transform child = obstacle.transform.GetChild(i);
                FallingController fallingCtrl = child.gameObject.GetComponent<FallingController>();
                if (fallingCtrl != null)
                {
                    fallingCtrl.player = player;
                }
            }
           
            lastObstaclePosition = obstacle.transform.position.x + compoWidth;
            //generatePowerUps(obstacle.transform.position);
        }
            //if (obstacle.tag == "Platform")
            //{
            //    int morePlatforms = Random.Range(0, 5);
            //    for (int i = 0; i < morePlatforms; i++)
            //    {
            //        obstacle = Instantiate(obstaclePrefabs[prefabType]);
            //        obstacle.transform.position = new Vector3(player.position.x + 20 + (i + 1) * 12, Random.Range(minPlatformY, maxPlatformY), 0);
            //        lastGeneratedPlatformX = obstacle.transform.position.x;
            //        if (Random.Range(0, 1) < 0.5f)
            //        {
            //            generatePowerUps(new Vector3(obstacle.transform.position.x, obstacle.transform.position.y + 1, 0));
            //        }
            //    }

        //    lastGeneratedPlatformX = obstacle.transform.position.x;
        //}
        //}
    }

    private void generatePowerUps(Vector3 position)
    {
        GameObject coin = Instantiate(coinPrefab);
        coin.transform.position = position;
        
        GameObject oneup = Instantiate(oneupPrefab);
        oneup.transform.position = position;
    }

    void Shake()
    {
        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            Camera.main.transform.position = new Vector3(x, y, originalCamPos.z);
        }

        Camera.main.transform.position = originalCamPos;
    }
}
