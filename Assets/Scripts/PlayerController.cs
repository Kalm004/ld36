using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public int maxLifes;
    public Image[] lifesImages;
    public float stopTimeOnCollision;
    //public float runningSpeed;
    public float sprintingSpeed;
    public float sprintingTime;
    public Transform enemy;
    public float distanceOnSprinting = 4;
    public float liveDistance = 2;
    public float maxJumpingTime;
    public float minEnemyDistance = 5;
    public AudioSource lostLife;
    public ParticleSystem slideEffect;

    private Rigidbody2D rb2d;
    private float startSprintingPosition = 0;
    private Animator animator;
    private float jumpingTime = 0;
    private states status
    {
        get
        {
            return stat;
        }
        set
        {
            if (stat != value)
            {
                if (value == states.slide)
                {
                    slideEffect.Play();
                } else
                {
                    slideEffect.Stop();
                }
                stat = value;
                animator.SetInteger("status", (int)value);
            }
        }
    }
    private states stat;
    private float deathTime;

    private enum states
    {
        running = 0,
        jumping = 1,
        resting = 2,
        sprinting = 3,
        falling = 4,
        hit = 5,
        hitDeath = 6,
        death = 7,
        slide = 8
    }

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        status = states.resting;
        rb2d = GetComponent<Rigidbody2D>();
        GameManager.lifes = maxLifes;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        //lifesText.text = "Lifes: " + GameManager.lifes.ToString();
        if (GameManager.lifes > 0)
        {
            float speed = GameManager.currentSpeed;
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                && (status == states.running || status == states.sprinting))
            {
                status = states.jumping;
                animator.SetBool("isJumping", true);
            }
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                && status == states.jumping)
            {
                jumpingTime += Time.deltaTime;
                if (jumpingTime <= maxJumpingTime)
                {
                    rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
                }
            }
            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && status == states.running) {
                status = states.slide;
            }
            if ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) && status == states.slide)
            {
                status = states.running;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {
                jumpingTime = 0;
                status = states.falling;
            }
            if (status == states.sprinting)
            {
                if (transform.position.x >= startSprintingPosition + distanceOnSprinting)
                {
                    transform.position = new Vector3(startSprintingPosition + distanceOnSprinting, transform.position.y, 0);
                    status = states.resting;
                }
                else
                {
                    speed = sprintingSpeed;
                }
            }
            if (status == states.resting || status == states.hit)
            {
                float targetPos = enemy.transform.position.x + minEnemyDistance + liveDistance * GameManager.lifes;
                if (transform.position.x <= targetPos)
                {
                    transform.position = new Vector3(targetPos, transform.position.y, 0);
                    status = states.running;
                }
                else
                {
                    speed = 0;
                }
            }
            transform.Translate(speed * Time.deltaTime, 0, 0);

            if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && status != states.sprinting && status != states.jumping && status != states.falling)
            {
                status = states.sprinting;
                startSprintingPosition = transform.position.x;
            }
        } else
        {
            if (status == states.hitDeath)
            {
                if (Time.time > deathTime + 0.2f) {
                    status = states.death;
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        bool damage = false;
        if (collision.collider.tag == "Obstacle")
        {
            GameManager.lifes--;
            damage = true;
            lostLife.Play();
        }
        if (collision.collider.tag == "Spikes")
        {
            GameManager.lifes = 0;
            damage = true;
            lostLife.Play();
        }
        if (damage) {
            lifesImages[GameManager.lifes].enabled = false;
            //Destroy(collision.collider.gameObject);
            if (GameManager.lifes > 0)
            {
                status = states.hit;
            } else
            {
                status = states.hitDeath;
                deathTime = Time.time;
            }
        }
        if (collision.collider.tag == "Floor")
        {
            if (status == states.falling)
            {
                animator.SetBool("isJumping", false);
                status = states.resting;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            GameManager.score += 100;
        }
        if (collision.tag == "1up")
        {
            if (GameManager.lifes < maxLifes)
            {
                Destroy(collision.gameObject);
                GameManager.lifes++;
                lifesImages[GameManager.lifes].enabled = true;
            }
        }
    }
}
