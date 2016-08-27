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

    private float elapsedTime = 0;
    private float lastGeneratedPlatformX = 0;

    public void Awake()
    {
        GameManager.restart();
    }

    // Use this for initialization
    void Start()
    {
        generateObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.lifes > 0)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > generateInterval)
            {
                generateObstacle();
                elapsedTime = 0;
            }
            scoreText.text = "Score: " + GameManager.score;
        }
        else
        {
            gameOver.SetActive(true);
        }
    }

    private void generateObstacle()
    {
        if (lastGeneratedPlatformX < player.position.x + 10)
        {
            int prefabType = Random.Range(0, obstaclePrefabs.Length);
            GameObject obstacle = Instantiate(obstaclePrefabs[prefabType]);
            obstacle.transform.position = new Vector3(player.position.x + 20, obstacle.transform.position.y, 0);
            if (obstacle.tag == "Platform")
            {
                int morePlatforms = Random.Range(0, 5);
                for (int i = 0; i < morePlatforms; i++)
                {
                    obstacle = Instantiate(obstaclePrefabs[prefabType]);
                    obstacle.transform.position = new Vector3(player.position.x + 20 + (i + 1) * 12, Random.Range(minPlatformY, maxPlatformY), 0);
                    lastGeneratedPlatformX = obstacle.transform.position.x;
                    if (Random.Range(0, 1) < 0.5f)
                    {
                        generatePowerUps(new Vector3(obstacle.transform.position.x, obstacle.transform.position.y + 1, 0));
                    }
                }

                lastGeneratedPlatformX = obstacle.transform.position.x;
            }
        }
    }

    private void generatePowerUps(Vector3 position)
    {
        float value = Random.Range(0f, 1f);
        if (value < 0.2f)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.transform.position = position;
        }
        else if (value < 0.4f && GameManager.lifes < 3)
        {
            GameObject oneup = Instantiate(oneupPrefab);
            oneup.transform.position = position;
        }
    }
}
