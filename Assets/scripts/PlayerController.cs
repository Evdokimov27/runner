using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private CapsuleCollider col;
    private Animator anim;
    private Score score;
    private Vector3 dir;

    [SerializeField] private float speed;
    [SerializeField] private int _timeSpeedUpSecond;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private int coins;
    [SerializeField] public int diamond;
    [SerializeField] private Text diamondText;
    [SerializeField] public GameObject losePanel;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private Text coinsText;
    [SerializeField] private Score Score;
    [SerializeField] private Text maxScore;
    [SerializeField] private GameObject Player;
    [SerializeField] private Image Immortal;
    [SerializeField] private GameObject Sheld;
    [SerializeField] private float fill;
    [SerializeField] public Transform spawnPoint;


    private bool isSliding;
    [SerializeField] public bool isImmortal;
    private bool jump;

    private int rightline = 3;
    private int leftline = -1;
    [SerializeField] private int lineToMove = 1;
    public float lineDistance = 4;
    private float maxSpeed = 110;

    void Start()
    {
        fill = 0f;
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        col = GetComponent<CapsuleCollider>();
        score = scoreText.GetComponent<Score>();
        Time.timeScale = 1;
        coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
        StartCoroutine(SpeedIncrease());
        isImmortal = false;
    }

    private void Update()
    {
        Immortal.fillAmount = fill;

        if (Time.timeScale == 1)
        {
            losePanel.SetActive(false);
        }

        if (isImmortal == true && fill >= 0)
        {
            fill -= Time.deltaTime * 1 / 5;
        }
        if (isImmortal == false && fill <= 1)
        {
            fill += Time.deltaTime * 1 / 2;
        }



        if (SwipeController.swipeRight)
        {
            if (lineToMove < rightline)
                lineToMove++;
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > leftline)
                lineToMove--;
        }

        if (SwipeController.swipeUp)
        {
            if (controller.isGrounded)
                StartCoroutine(Jump());

        }

        if (SwipeController.swipeDown)
        {
            StartCoroutine(Slide());
        }


        if (controller.isGrounded && !isSliding)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == -1)
            targetPosition += 2 * Vector3.left * lineDistance;
        else if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;
        else if (lineToMove == 3)
            targetPosition += 2 * Vector3.right * lineDistance;

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);





    }

    private IEnumerator Jump()
    {
        gravity = -50;
        dir.y = jumpForce;
        anim.SetTrigger("isJumping");
        anim.SetTrigger("jump");
        yield return new WaitForSeconds(0);
    }

    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "down")
        {
            if (isImmortal)
            {
                ReincPos();
            }
            else {
                int lastRunScore = int.Parse(Score.scoreText.text.ToString());
                PlayerPrefs.SetInt("lastRunScore", lastRunScore);
                losePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if (hit.gameObject.tag == "obstacle")
        {
            if (isImmortal)
                Destroy(hit.gameObject);
            else
            {
                int lastRunScore = int.Parse(Score.scoreText.text.ToString());
                PlayerPrefs.SetInt("lastRunScore", lastRunScore);
                losePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coins++;
            PlayerPrefs.SetInt("coins", coins);
            coinsText.text = coins.ToString();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BonusStar")
        {
            StartCoroutine(StarBonus());
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BonusShield")
        {
            fill = 1;
            StartCoroutine(ShieldBonus());
            Destroy(other.gameObject);
        }
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(_timeSpeedUpSecond);
        if (speed < maxSpeed)
        {
            speed += 1;
            StartCoroutine(SpeedIncrease());
        }
    }

    private IEnumerator Slide()
    {
        gravity = -150;
        col.center = new Vector3(0, 3f, 0f);
        col.height = 4;
        controller.center = new Vector3(0, 3f, 0f);
        controller.height = 4;

        anim.SetTrigger("slide");

        yield return new WaitForSeconds(1);



        yield return new WaitForSeconds(2 / 3);

        col.center = new Vector3(0, 3, 0);
        col.height = 6;
        controller.center = new Vector3(0, 3, 0);
        controller.height = 6;

    }

    private IEnumerator StarBonus()
    {
        //score.scoreMultiplier = 2;

        yield return new WaitForSeconds(5);

        //score.scoreMultiplier = 1;
    }

    public void ReincPos()
    {
        lineToMove = 1;
        Player.transform.position = spawnPoint.transform.position; 
    }
    public IEnumerator Reincornation()
    {
        Time.timeScale = 1;
        Sheld.SetActive(true);
        isImmortal = true;
        fill = 1;
        fill -= Time.deltaTime * 5;
        yield return new WaitForSeconds(5);
        isImmortal = false;
        Sheld.SetActive(false);

    }
    public IEnumerator ShieldBonus()
    {
        Sheld.SetActive(true);
        isImmortal = true;
        fill -= Time.deltaTime * 5;
        yield return new WaitForSeconds(5);
        isImmortal = false;
        Sheld.SetActive(false);
    }
    public void CheckFill()
    {
        if (fill >= 1 && Time.timeScale !=0)
        {
            StartCoroutine(ShieldBonus());
        }
    }
}