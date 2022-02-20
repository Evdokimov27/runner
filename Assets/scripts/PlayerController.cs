using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private CapsuleCollider col;
    private Animator anim;
    //private Score score;
    private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private int coins;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private Text coinsText;
   // [SerializeField] private Score scoreScript;

    private bool isSliding;
    private bool isImmortal;
    private bool jump;

    private int lineToMove = 1;
    public float lineDistance = 4;
    private float maxSpeed = 110;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        col = GetComponent<CapsuleCollider>();
        //score = scoreText.GetComponent<Score>();
        //score.scoreMultiplier = 1;
        Time.timeScale = 1;
        coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
        StartCoroutine(SpeedIncrease());
        isImmortal = false;
    }

    private void Update()
    {


        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
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
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);

        if (speed <= 100)
        {
            speed += 0.1f * Time.deltaTime;
        }
        


    }

    private IEnumerator Jump()
    {
        gravity = -50;
        dir.y = jumpForce;
        anim.SetTrigger("isJumping");
        anim.SetTrigger("jump");
        anim.SetBool("jumper", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("jumper", false);
    }

    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obstacle")
        {
            if (isImmortal)
                Destroy(hit.gameObject);
            else
            {
                losePanel.SetActive(true);
              //  int lastRunScore = int.Parse(scoreScript.scoreText.text.ToString());
               // PlayerPrefs.SetInt("lastRunScore", lastRunScore);
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
            StartCoroutine(ShieldBonus());
            Destroy(other.gameObject);
        }
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(1);
        if (speed < maxSpeed)
        {
            speed += 1;
            StartCoroutine(SpeedIncrease());
        }
    }

    private IEnumerator Slide()
    {
        gravity = -150;
        col.center = new Vector3(0, 1, 0f);
        col.height = 2;
        controller.center = new Vector3(0, 1, 0f);
        controller.height = 2;
        isSliding = true;
        anim.SetBool("isRunning", false);
        anim.SetTrigger("isSliding");
        anim.SetTrigger("slide");

        anim.SetBool("slider", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("slider", false);


        yield return new WaitForSeconds(2/3);

        col.center = new Vector3(0, 1.48452f, 0);
        col.height = 3  ;
        controller.center = new Vector3(0, 1.48452f, 0);
        controller.height = 3;
        isSliding = false;
    }

    private IEnumerator StarBonus()
    {
        //score.scoreMultiplier = 2;

        yield return new WaitForSeconds(5);

        //score.scoreMultiplier = 1;
    }

    private IEnumerator ShieldBonus()
    {
        isImmortal = true;

        yield return new WaitForSeconds(5);

        isImmortal = false;
    }
}