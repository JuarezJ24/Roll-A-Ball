using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
   
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public TextMeshProUGUI timerText;
    public GameObject loseText;
    public GameObject resetButton;
    public GameObject nextButton;
    public float jumpForce = 1000;
    public float speed = 0;

    private bool Grounded;
    private int count;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float totalTime;
    private float timeLeft;
    private bool gameWon;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        loseText.SetActive(false);
        resetButton.SetActive(false);
        nextButton.SetActive(false);
        totalTime = 35;
        timeLeft = totalTime;
        timerText.text = "Timer: " + timeLeft.ToString();
        gameWon = false;
    }

    /*void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }*/

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            winTextObject.SetActive(true);
            nextButton.SetActive(true);
            gameWon = true;
        }
    }
    // Update is called once per frame
     
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed * Time.deltaTime);

        timerText.text = "Timer: " + timeLeft.ToString("F1");
        if (gameWon== false)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                gameObject.SetActive(false);
                loseText.SetActive(true);
                resetButton.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            StartCoroutine(Jump());
        }
    }
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.1f);
        rb.AddForce(new Vector3(0, jumpForce, 0));
        Grounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
        if (other.gameObject.CompareTag("ground"))
        {
            Grounded = true;
        }
    }

}
