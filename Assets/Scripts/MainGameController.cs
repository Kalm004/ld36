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

    public float lastObstaclePosition = 0;

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
    }

    private void generateObstacle()
    {
        if (player.position.x + 10 > lastObstaclePosition)
        {
            int prefabType = Random.Range(0, obstaclePrefabs.Length);
            GameObject obstacle = Instantiate(obstaclePrefabs[prefabType]);
            obstacle.transform.position = new Vector3(player.position.x + 20, obstacle.transform.position.y, 0);
            FallingController fallingCtrl = obstacle.GetComponent<FallingController>();
            if (fallingCtrl != null)
            {
                fallingCtrl.player = player;
            }
            lastObstaclePosition = obstacle.transform.position.x;
            generatePowerUps(obstacle.transform.position);
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
}
