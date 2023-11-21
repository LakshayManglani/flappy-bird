using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float upwardForce = 5f; // Upward force to be applied
    public AudioClip jumpSound;
    public GameObject retryMenu;
    public GameObject pauseMenu;
    public AudioSource backgroundMusic;

    public AudioSource birdHitSound;
    public AudioSource coinCollectSound;

    public TextMeshProUGUI score;
    public int scoreValue = 0;

    private Rigidbody2D rb2d;
    private bool isJumping = false;
    private AudioSource audioSource;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        score.text = "Score: " + scoreValue.ToString();
    }

    private void Update()
    {
        // Get input from update method
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 0;
            backgroundMusic.Pause();
            birdHitSound.Play();
            retryMenu.SetActive(true);
        }
    }

    private async void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            Destroy(collider.gameObject);
            scoreValue++;
            score.text = "Score: " + scoreValue.ToString();
            coinCollectSound.Play();
            await Task.Delay(500);
            coinCollectSound.Stop();
        }
    }

    void FixedUpdate()
    {
        // 
        if (isJumping && rb2d.velocity.y <= 2f)
        {
            if (audioSource.clip != jumpSound)
            {
                audioSource.Stop();
                audioSource.clip = jumpSound;
            }
            audioSource.Play();

            rb2d.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);
            isJumping = false;
        }
    }
}
