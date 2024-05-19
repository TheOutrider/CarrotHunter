using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed;
    float hInput, vInput;
    int score = 0;
    public GameObject winText;
    public TextMeshProUGUI scoreText;
    public AudioSource audioSource;
    public AudioClip killSound1, killSound2, bhoiIntroSound, bhoiWinSound;
    SpriteRenderer spriteRenderer;
    public Sprite originalFace, killFace;


    void Start()
    {
        scoreText.text = " : Happy Hunting";
        spriteRenderer = GetComponent<SpriteRenderer>();
        // spriteRenderer.sprite = originalFace;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        if (score < 7)
        {
            hInput = joystick.Horizontal * moveSpeed;
            vInput = joystick.Vertical * moveSpeed;
            transform.Translate(hInput, vInput, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Deer")
        {
            score++;
            scoreText.text = " : " + score.ToString();

            if (score >= 7)
            {
                winText.SetActive(true);
                audioSource.clip = bhoiWinSound;
                audioSource.Play();
            }
            else
            {
                Debug.Log("TESRING CHANGES");
                audioSource.clip = score % 2 == 0 ? killSound1 : killSound2;
                audioSource.Play();
                spriteRenderer.sprite = score % 2 == 0 ? killFace : originalFace;
            }

            Destroy(collision.gameObject);
        }
    }


}
