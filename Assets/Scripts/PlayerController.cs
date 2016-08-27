using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public int maxLifes;
    public Text lifesText;
    public float stopTimeOnCollision;
    //public float runningSpeed;
    public float sprintingSpeed;
    public float sprintingTime;
    public Transform enemy;
    public float distanceOnSprinting = 4;
    public float liveDistance = 2;
    public float maxJumpingTime;

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
                stat = value;
                animator.SetInteger("status", (int)value);
            }
        }
    }
    private states stat;

    private enum states
    {
        running = 0,
        jumping = 1,
        resting = 2,
        sprinting = 3
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
        lifesText.text = "Lifes: " + GameManager.lifes.ToString();
        if (GameManager.lifes > 0)
        {
            float speed = GameManager.currentSpeed;
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                && status != states.resting)
            {
                jumpingTime += Time.deltaTime;
                if (jumpingTime <= maxJumpingTime) {
                    rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
                    status = states.jumping;
                    animator.SetBool("isJumping", true);
                }
            }
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)) {
                jumpingTime = 0;
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
            if (status == states.resting)
            {
                float targetPos = enemy.transform.position.x + liveDistance * GameManager.lifes;
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
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && status != states.sprinting && status != states.jumping)
        {
            status = states.sprinting;
            startSprintingPosition = transform.position.x;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            GameManager.lifes--;
            //Destroy(collision.collider.gameObject);
            status = states.resting;
        }
        if (collision.collider.tag == "Floor")
        {
            if (status == states.jumping)
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
            }
        }
    }
}
